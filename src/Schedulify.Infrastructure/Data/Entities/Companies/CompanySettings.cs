using Schedulify.Infrastructure.Data.Entities.Base;

namespace Schedulify.Infrastructure.Data.Entities.Companies;

internal class CompanySettings : Entity
{
    public int MaximumBranches { get; set; }
    public virtual required Company Company { get; set; }
}