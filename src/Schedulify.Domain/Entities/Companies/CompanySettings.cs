using Schedulify.Domain.Entities.Base;

namespace Schedulify.Domain.Entities.Companies;

internal class CompanySettings : Entity
{
    public int MaximumBranches { get; set; }
    public virtual required Company Company { get; set; }
}