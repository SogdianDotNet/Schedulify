using Schedulify.Infrastructure.Data.Entities.Base;
using Schedulify.Infrastructure.Data.Entities.Vats;

namespace Schedulify.Infrastructure.Data.Entities.Common;

internal class Country : BaseEntity
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required string IsoA2 { get; set; }
    public virtual ICollection<VatRate>? VatRates { get; set; }
    public virtual ICollection<Address>? Addresses { get; set; }
}