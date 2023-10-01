namespace Schedulify.Domain.Entities.Base;

internal interface IAuditEntity
{
    Guid? UserId { get; set; }
}
