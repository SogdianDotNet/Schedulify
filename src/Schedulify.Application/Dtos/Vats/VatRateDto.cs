using Schedulify.Application.Dtos.Base;

namespace Schedulify.Application.Dtos.Vats;

public class VatRateDto : Dto
{
    public decimal Rate { get; set; }
    public DateTime ActiveFrom { get; set; }
    public DateTime? ActiveTo { get; set; }
}