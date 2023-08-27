using Schedulify.Infrastructure.Data.Entities.Base;
using Schedulify.Infrastructure.Data.Entities.Common;

namespace Schedulify.Infrastructure.Data.Entities.Vats;

internal class VatRate : Entity
{
    public decimal Rate { get; set; }
    public DateTime ActiveFrom { get; set; }
    public DateTime? ActiveTo { get; set; }
    public virtual Country? Country { get; set; }
}