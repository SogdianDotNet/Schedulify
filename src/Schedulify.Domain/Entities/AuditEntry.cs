using Schedulify.Domain.Entities.Base;

namespace Schedulify.Domain.Entities;

internal class AuditEntry : Entity
{
    public required AuditAction Action { get; set; }
    public required string TableName { get; set; }
    public required string OldValues { get; set; }
    public required string NewValues { get; set; }
    public required string AffectedColumns { get; set; }
    public required string PrimaryKey { get; set; }
    public Guid? UserId { get; set; }
}