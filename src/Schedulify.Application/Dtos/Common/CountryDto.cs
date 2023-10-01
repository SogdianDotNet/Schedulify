using Schedulify.Application.Dtos.Base;
using Schedulify.Application.Dtos.Vats;

namespace Schedulify.Application.Dtos.Common;

public class CountryDto : Dto
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required string IsoA2 { get; set; }
    public List<VatRateDto>? VatRates { get; set; } = new();
}