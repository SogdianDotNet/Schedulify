namespace Schedulify.Domain.Entities.Base;

internal abstract class SoftDeleteEntity : Entity, ISoftDeleteEntity
{
    public bool IsDeleted { get; set; }
    public DateTime? DeletedOnUtc { get; set; }
}