namespace Schedulify.Infrastructure.Data.Entities.Companies;

using Employees;

internal class CompanyBranchEmployee
{
    public Guid CompanyBranchId { get; set; }
    public Guid EmployeeId { get; set; }
    public required CompanyBranch CompanyBranch { get; set; }
    public required Employee Employee { get; set; }
}