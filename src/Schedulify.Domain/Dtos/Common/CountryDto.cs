using Schedulify.Domain.Dtos.Base;
using Schedulify.Domain.Dtos.Vats;

namespace Schedulify.Domain.Dtos.Common;

public class CountryDto : Dto
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required string IsoA2 { get; set; }
    public List<VatRateDto>? VatRates { get; set; } = new();
}