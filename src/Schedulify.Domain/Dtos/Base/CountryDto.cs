namespace Schedulify.Domain.Dtos.Base;

public class CountryDto : BaseDto
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required string IsoA2 { get; set; }
}