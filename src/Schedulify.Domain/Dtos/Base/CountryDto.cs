using Schedulify.Domain.Dtos.Common;
using Schedulify.Domain.Dtos.Vats;

namespace Schedulify.Domain.Dtos.Base;

public class CountryDto : BaseDto
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required string IsoA2 { get; set; }
    public IEnumerable<AddressDto> Addresses { get; set; } = Enumerable.Empty<AddressDto>();
    public IEnumerable<VatRateDto> VatRates { get; set; } = Enumerable.Empty<VatRateDto>();
}