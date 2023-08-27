using Schedulify.Infrastructure.Data.Entities.Base;

namespace Schedulify.Infrastructure.Data.Entities;

internal class AuditEntry : BaseEntity
{
    public required AuditAction Action { get; set; }
    public required string TableName { get; set; }
    public required string OldValues { get; set; }
    public required string NewValues { get; set; }
    public required string AffectedColumns { get; set; }
    public required string PrimaryKey { get; set; }
    public Guid? UserId { get; set; }
}