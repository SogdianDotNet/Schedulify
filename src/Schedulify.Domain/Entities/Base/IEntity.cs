namespace Schedulify.Domain.Entities.Base;

internal interface IEntity
{
    Guid Id { get; set; }
    DateTime CreatedOnUtc { get; set; }
    DateTime? ModifiedOnUtc { get; set; }
}
