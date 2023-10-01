namespace Schedulify.Domain.Entities.Companies;

using Common;

internal sealed class CompanyBranchAddress
{
    public Guid CompanyBranchId { get; set; }
    public Guid AddressId { get; set; }
    public required CompanyBranch CompanyBranch { get; set; }
    public required Address Address { get; set; }
}