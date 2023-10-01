using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Schedulify.Domain.Entities.Base;
using Schedulify.Infrastructure.Data;

namespace Schedulify.Infrastructure.Repositories;

internal abstract class Repository<T> : IRepository<T> where T : Entity
{
    protected readonly SchedulifyDbContext _dbContext;
    
    protected Repository(SchedulifyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyCollection<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return (await _dbContext.Set<T>().ToListAsync(cancellationToken)).AsReadOnly();
    }

    public async Task<IReadOnlyCollection<T>> FindAsync(Expression<Func<T, bool>>? expression, CancellationToken cancellationToken = default)
    {
        if (expression is null)
        {
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        return await _dbContext.Set<T>().Where(expression).ToListAsync(cancellationToken);
    }

    public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        return await CreateAsync(entity, null, cancellationToken);
    }

    public async Task<T> CreateAsync(T entity, List<Expression<Func<T, object>>>? includes = null, CancellationToken cancellationToken = default)
    {
        if (entity is null)
        {
            ArgumentNullException.ThrowIfNull(entity);
        }

        return (await UpdateInternalAsync(new[] { entity }, includes, cancellationToken)).Single();
    }

    public async Task<T> UpdateAsync(T entity, List<Expression<Func<T, object>>>? includes = null, CancellationToken cancellationToken = default)
    {
        if (entity is null)
        {
            ArgumentNullException.ThrowIfNull(entity);
        }

        return (await UpdateInternalAsync(new[] { entity }, includes, cancellationToken)).Single();
    }

    public async Task<IReadOnlyCollection<T>> CreateRangeAsync(IReadOnlyCollection<T> entities, CancellationToken cancellationToken = default)
    {
        if (entities is null || !entities.Any())
        {
            throw new ArgumentNullException(nameof(entities));
        }

        return (await UpdateInternalAsync(entities, null, cancellationToken)).ToList().AsReadOnly();
    }

    public async Task<IEnumerable<T>> UpdateRangeAsync(IReadOnlyCollection<T> entities, CancellationToken cancellationToken = default)
    {
        if (entities is null || !entities.Any())
        {
            return new List<T>().AsReadOnly();
        }

        foreach (var entity in entities)
        {
            var entry = _dbContext.Entry(entity);

            if (entry.State == EntityState.Detached && _dbContext.Entry(entity).IsKeySet)
            {
                _dbContext.Attach(entity);
                entry.State = EntityState.Modified;
            }

            if (!_dbContext.Entry(entity).IsKeySet)
            {
                _dbContext.Update(entity);
            }
        }

        return entities;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var dbEntity = await _dbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken);

        if (dbEntity is null)
        {
            throw new InvalidOperationException($"Entity with id {id} does not exist");
        }
        
        _dbContext.Remove(dbEntity);
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        if (!await _dbContext.Set<T>().AnyAsync(x => x.Id == entity.Id, cancellationToken))
        {
            throw new InvalidOperationException($"Entity with id {entity.Id} does not exist");
        }
        
        _dbContext.Remove(entity);
    }

    public async Task DeleteRangeAsync(IReadOnlyCollection<Guid> ids, CancellationToken cancellationToken = default)
    {
        var entities = await _dbContext.Set<T>().Where(x => ids.Contains(x.Id)).ToListAsync(cancellationToken);

        if (entities.Count == 0)
        {
            return;
        }

        _dbContext.RemoveRange(entities);
    }

    public void DeleteRange(IReadOnlyCollection<T> entities, CancellationToken cancellationToken = default)
    {
        _dbContext.RemoveRange(entities);
    }

    #region Helpers
    
    private async Task<IReadOnlyCollection<T>> UpdateInternalAsync(IReadOnlyCollection<T> entities, List<Expression<Func<T, object>>>? includes = null, CancellationToken cancellationToken = default)
    {
        foreach (var entity in entities)
        {
            var entry = _dbContext.Entry(entity);

            if (entry.State == EntityState.Detached && _dbContext.Entry(entity).IsKeySet)
            {
                _dbContext.Attach(entity);
                entry.State = EntityState.Modified;
                foreach (var property in entity.GetType().GetProperties().Where(property => typeof(Entity).IsAssignableFrom(property.PropertyType)))
                {
                    var subEntity = (Entity?)property.GetValue(entity);
                    if (subEntity is not null && _dbContext.Entry(subEntity).IsKeySet)
                    {
                        var subentry = _dbContext.Entry(subEntity);
                        _dbContext.Attach(subEntity);
                        subentry.State = EntityState.Modified;
                    }
                }

                if (includes?.Any() ?? false)
                {
                    await AttachIncludedCollections(_dbContext.Entry(entity), includes, cancellationToken);
                }
            }

            if (!_dbContext.Entry(entity).IsKeySet)
            {
                _dbContext.Update(entity);
            }
        }
            
        return entities;
    }
    
    private async Task AttachIncludedCollections(EntityEntry<T> entity, List<Expression<Func<T, object>>> includes, CancellationToken cancellationToken = default)
    {
        var includedCollections = entity.Collections.Where(c =>
            includes.Any(
                i => i.Body.ToString().Contains(c.Metadata.Name) && i.Body.Type == c.Metadata.ClrType));

        foreach (var collectionEntry in includedCollections)
        {
            await AttachCollectionItems(collectionEntry, cancellationToken);
        }
    }

    private async Task AttachCollectionItems(CollectionEntry collectionEntry, CancellationToken cancellationToken = default)
    {
        var currentCollection = (collectionEntry.CurrentValue as IEnumerable<Entity>).ToList();
        var existingCollection = await (collectionEntry.Query() as IQueryable<Entity>).ToListAsync(cancellationToken);

        foreach (var entity in currentCollection.Except(existingCollection))
        {
            AttachCollectionItem(entity, EntityState.Added);
        }

        foreach (var entity in existingCollection.Except(currentCollection))
        {
            AttachCollectionItem(entity, EntityState.Deleted);
        }

        foreach (var entity in existingCollection.Intersect(currentCollection))
        {
            AttachCollectionItem(entity, EntityState.Modified);
        }
    }

    private void AttachCollectionItem(Entity entity, EntityState entityState)
    {
        var entry = _dbContext.Entry(entity);
        _dbContext.Attach(entity);
        entry.State = entityState;
    }

    #endregion
}