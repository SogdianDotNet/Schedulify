namespace Schedulify.Infrastructure.Data.Entities.Base;

internal abstract class BaseEntity : IBaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedOnUtc { get; set; }
}
