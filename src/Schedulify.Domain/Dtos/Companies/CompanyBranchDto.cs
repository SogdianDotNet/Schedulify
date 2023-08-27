using Schedulify.Domain.Dtos.Common;
using Schedulify.Domain.Dtos.Employees;

namespace Schedulify.Domain.Dtos.Companies;

public class CompanyBranchDto
{
    public required string Name { get; set; }
    public CompanyBranchSettingsDto? CompanyBranchSettings { get; set; }
    public AddressDto? Address { get; set; }
    public List<EmployeeDto> Employees { get; set; } = new();
}