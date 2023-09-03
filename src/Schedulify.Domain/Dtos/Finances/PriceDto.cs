using Schedulify.Domain.Dtos.Base;
using Schedulify.Domain.Dtos.Vats;

namespace Schedulify.Domain.Dtos.Finances;

public class PriceDto : Dto
{
    public decimal Value { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public required VatRateDto Vat { get; set; }
    public required CurrencyDto Currency { get; set; }
}