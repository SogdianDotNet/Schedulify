using Schedulify.Domain.Dtos.Base;

namespace Schedulify.Domain.Dtos.Finances;

public class CurrencyDto : Dto
{
    public required string Code { get; set; } // Currency code (e.g., USD, EUR)
    public required string Name { get; set; } // Currency name (e.g., US Dollar, Euro)
}