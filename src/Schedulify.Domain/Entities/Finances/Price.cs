using Schedulify.Domain.Entities.Base;
using Schedulify.Domain.Entities.Vats;

namespace Schedulify.Domain.Entities.Finances;

internal class Price : Entity
{
    public decimal Value { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public virtual required VatRate Vat { get; set; }
    public virtual required Currency Currency { get; set; }
}