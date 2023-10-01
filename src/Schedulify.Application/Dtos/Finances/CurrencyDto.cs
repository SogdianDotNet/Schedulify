using Schedulify.Application.Dtos.Base;

namespace Schedulify.Application.Dtos.Finances;

public class CurrencyDto : Dto
{
    public required string Code { get; set; } // Currency code (e.g., USD, EUR)
    public required string Name { get; set; } // Currency name (e.g., US Dollar, Euro)
}