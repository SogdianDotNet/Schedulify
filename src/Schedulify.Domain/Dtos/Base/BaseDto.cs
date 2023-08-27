namespace Schedulify.Domain.Dtos.Base;

internal interface IBaseDto
{
    Guid Id { get; set; }
    DateTime CreatedOnUtc { get; set; }
    DateTime? ModifiedOnUtc { get; set; }
    bool IsDeleted { get; set; }
    DateTime? DeletedOnUtc { get; set; }
}

public abstract class BaseDto
{
    public Guid Id { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedOnUtc { get; set; }
}