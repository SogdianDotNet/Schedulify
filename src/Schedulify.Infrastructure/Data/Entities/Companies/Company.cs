using Schedulify.Infrastructure.Data.Entities.Base;

namespace Schedulify.Infrastructure.Data.Entities.Companies;

internal class Company : BaseEntity
{
    public required string Name { get; set; }
    public required string Website { get; set; }
    public required string LegalStructure { get; set; }
    public required string CoCNumber { get; set; }
    public required string Email { get; set; }
    public required string Description { get; set; }
    public virtual required CompanySettings CompanySettings { get; set; }
    public virtual ICollection<CompanyBranch>? CompanyBranches { get; set; }
}