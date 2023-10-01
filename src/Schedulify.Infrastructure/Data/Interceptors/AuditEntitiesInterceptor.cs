using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using Schedulify.Application.Providers;
using Schedulify.Domain.Attributes;
using Schedulify.Domain.Entities;
using Schedulify.Domain.Entities.Base;

namespace Schedulify.Infrastructure.Data.Interceptors;

internal sealed class AuditEntitiesInterceptor : SaveChangesInterceptor
{
    private readonly IClaimsProvider _claimProvider;

    public AuditEntitiesInterceptor(IClaimsProvider claimProvider)
    {
        _claimProvider = claimProvider;
    }
    
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        UpdateAuditColumns(eventData.Context.ChangeTracker.Entries());
        
        if (eventData.Context is null)
        {
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }
            
        OnBeforeSaveChanges(eventData);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void OnBeforeSaveChanges(DbContextEventData eventData)
    {
        eventData.Context?.ChangeTracker.DetectChanges();

        var auditEntries = Create(eventData.Context.ChangeTracker.Entries().ToList());

        eventData.Context.AddRange(auditEntries);
    }

    private ICollection<AuditEntry> Create(ICollection<EntityEntry> entityEntry)
    {
        var auditEntries = new List<AuditEntry>();

        foreach (var entry in entityEntry)
        {
            var isDisabled = entry.Entity.GetType().IsAuditDisabled();

            if (isDisabled || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
            {
                continue;
            }

            var auditEntry = new AuditEntry
            {
                TableName = entry.Entity.GetType()
                    .Name,
                UserId = _claimProvider.UserId,
                Action = AuditAction.NotSpecified,
                OldValues = null,
                NewValues = null,
                AffectedColumns = null,
                PrimaryKey = null
            };

            SetAuditValues(entry, auditEntry);
            auditEntries.Add(auditEntry);
        }

        return auditEntries;
    }

    private void UpdateAuditColumns(IEnumerable<EntityEntry> entries)
    {
        var utcNow = DateTime.UtcNow;

        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added when entry.Entity is IEntity auditDate:
                    auditDate.CreatedOnUtc = utcNow;
                    auditDate.ModifiedOnUtc = utcNow;
                    break;

                case EntityState.Modified when entry.Entity is IEntity auditDate:
                    auditDate.ModifiedOnUtc = utcNow;
                    break;

                case EntityState.Deleted when entry.Entity is ISoftDeleteEntity softDeletable:
                    softDeletable.IsDeleted = true;
                    softDeletable.DeletedOnUtc = utcNow;
                    entry.State = EntityState.Modified;
                    break;
            }
        }
    }

    private static void SetAuditValues(EntityEntry entry, AuditEntry auditEntry)
    {
        var primaryKeys = new Dictionary<string, string>();
        var oldValues = new Dictionary<string, string>();
        var newValues = new Dictionary<string, string>();
        var changedColumns = new List<string>();

        foreach (var property in entry.Properties)
        {
            var propertyName = property.Metadata.Name;

            if (property.Metadata.IsPrimaryKey())
            {
                primaryKeys[propertyName] = property.CurrentValue?.ToString();
                continue;
            }

            switch (entry.State)
            {
                case EntityState.Added:
                    auditEntry.Action = AuditAction.Create;
                    newValues[propertyName] = property.CurrentValue?.ToString();
                    break;
                case EntityState.Deleted:
                    auditEntry.Action = AuditAction.Delete;
                    oldValues[propertyName] = property.OriginalValue?.ToString();
                    break;
                case EntityState.Modified:
                    if (property.IsModified)
                    {
                        changedColumns.Add(propertyName);
                        auditEntry.Action = AuditAction.Update;
                        oldValues[propertyName] = property.OriginalValue?.ToString();
                        newValues[propertyName] = property.CurrentValue?.ToString();
                    }
                    break;
            }
        }

        auditEntry.PrimaryKey = JsonConvert.SerializeObject(primaryKeys);
        auditEntry.OldValues = oldValues.Count == 0 ? null : JsonConvert.SerializeObject(oldValues);
        auditEntry.NewValues = newValues.Count == 0 ? null : JsonConvert.SerializeObject(newValues);
        auditEntry.AffectedColumns = changedColumns.Count == 0 ? null : JsonConvert.SerializeObject(changedColumns);
    }
}