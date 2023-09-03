namespace Schedulify.Infrastructure.Data.Entities.Base;

internal interface ISoftDeleteEntity
{
    bool IsDeleted { get; set; }
    DateTime? DeletedOnUtc { get; set; }
}