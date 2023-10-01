using Schedulify.Domain.Entities.Base;
using Schedulify.Domain.Entities.Vats;

namespace Schedulify.Domain.Entities.Common;

internal class Country : Entity
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required string IsoA2 { get; set; }
    public virtual ICollection<VatRate>? VatRates { get; set; }
    public virtual ICollection<Address>? Addresses { get; set; }
}