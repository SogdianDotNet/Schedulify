using Schedulify.Domain.Dtos.Base;

namespace Schedulify.Domain.Dtos.Common;

public class AddressDto : BaseDto
{
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string PostalCode { get; set; }
    public required int HouseNumber { get; set; }
    public string? HouseNumberAddition { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Fax { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}