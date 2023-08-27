namespace Schedulify.Infrastructure.Data.Entities.Base;

internal interface IBaseEntity
{
    Guid Id { get; set; }
    DateTime CreatedOnUtc { get; set; }
    DateTime? ModifiedOnUtc { get; set; }
    bool IsDeleted { get; set; }
    DateTime? DeletedOnUtc { get; set; }
}
