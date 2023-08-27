using Schedulify.Infrastructure.Data.Entities.Base;

namespace Schedulify.Infrastructure.Data.Entities.Companies;

internal class CompanySettings : BaseEntity
{
    public virtual required Company Company { get; set; }
}