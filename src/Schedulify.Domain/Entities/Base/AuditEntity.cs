namespace Schedulify.Domain.Entities.Base;

internal abstract class AuditEntity : Entity, IAuditEntity
{
    public Guid? UserId { get; set; }
}
