namespace Schedulify.Domain.Entities.Companies;

internal class CompanyBranch
{
    public required string Name { get; set; }
    public virtual required CompanyBranchSettings CompanyBranchSettings { get; set; }
    public virtual ICollection<CompanyBranchAddress>? CompanyBranchAddresses { get; set; }
    public virtual ICollection<CompanyBranchEmployee>? CompanyBranchEmployees { get; set; }
}