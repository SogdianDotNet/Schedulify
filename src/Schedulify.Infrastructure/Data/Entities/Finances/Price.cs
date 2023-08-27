using Schedulify.Infrastructure.Data.Entities.Base;
using Schedulify.Infrastructure.Data.Entities.Vats;

namespace Schedulify.Infrastructure.Data.Entities.Finances;

internal class Price : Entity
{
    public decimal Value { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public virtual required VatRate Vat { get; set; }
    public virtual required Currency Currency { get; set; }
}