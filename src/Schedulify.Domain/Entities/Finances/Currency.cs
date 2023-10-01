using Schedulify.Domain.Entities.Base;

namespace Schedulify.Domain.Entities.Finances;

internal abstract class Currency : Entity
{
    public required string Code { get; set; } // Currency code (e.g., USD, EUR)
    public required string Name { get; set; } // Currency name (e.g., US Dollar, Euro)
}