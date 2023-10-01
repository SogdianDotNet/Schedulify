using Schedulify.Application.Dtos.Common;
using Schedulify.Application.Dtos.Vats;

namespace Schedulify.Application.Dtos.Base;

public class CountryDto : Dto
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required string IsoA2 { get; set; }
    public IEnumerable<AddressDto> Addresses { get; set; } = Enumerable.Empty<AddressDto>();
    public IEnumerable<VatRateDto> VatRates { get; set; } = Enumerable.Empty<VatRateDto>();
}