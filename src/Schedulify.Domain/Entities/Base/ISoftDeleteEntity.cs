namespace Schedulify.Domain.Entities.Base;

internal interface ISoftDeleteEntity
{
    bool IsDeleted { get; set; }
    DateTime? DeletedOnUtc { get; set; }
}