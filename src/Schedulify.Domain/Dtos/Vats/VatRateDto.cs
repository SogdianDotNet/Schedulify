using Schedulify.Domain.Dtos.Base;

namespace Schedulify.Domain.Dtos.Vats;

public class VatRateDto : BaseDto
{
    public decimal Rate { get; set; }
    public DateTime ActiveFrom { get; set; }
    public DateTime? ActiveTo { get; set; }
}