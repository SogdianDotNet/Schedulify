namespace Schedulify.Infrastructure.Data.Entities.Base;

internal abstract class Entity : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
}
