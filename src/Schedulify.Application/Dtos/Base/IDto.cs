namespace Schedulify.Application.Dtos.Base;

internal interface IDto
{
    Guid Id { get; set; }
    DateTime CreatedOnUtc { get; set; }
    DateTime? ModifiedOnUtc { get; set; }
    bool IsDeleted { get; set; }
    DateTime? DeletedOnUtc { get; set; }
}