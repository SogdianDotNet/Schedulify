using Schedulify.Domain.Entities.Base;
using Schedulify.Domain.Entities.Common;

namespace Schedulify.Domain.Entities.Vats;

internal class VatRate : Entity
{
    public decimal Rate { get; set; }
    public DateTime ActiveFrom { get; set; }
    public DateTime? ActiveTo { get; set; }
    public virtual Country? Country { get; set; }
}