using Schedulify.Infrastructure.Data.Entities.Base;

namespace Schedulify.Infrastructure.Data.Entities.Finances;

internal abstract class Currency : BaseEntity
{
    public required string Code { get; set; } // Currency code (e.g., USD, EUR)
    public required string Name { get; set; } // Currency name (e.g., US Dollar, Euro)
}