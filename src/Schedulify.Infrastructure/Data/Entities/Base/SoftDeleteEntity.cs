namespace Schedulify.Infrastructure.Data.Entities.Base;

internal abstract class SoftDeleteEntity : Entity
{
    public bool IsDeleted { get; set; }
    public DateTime? DeletedOnUtc { get; set; }
}