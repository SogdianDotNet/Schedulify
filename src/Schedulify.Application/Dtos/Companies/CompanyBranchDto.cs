using Schedulify.Application.Dtos.Common;
using Schedulify.Application.Dtos.Employees;

namespace Schedulify.Application.Dtos.Companies;

public class CompanyBranchDto
{
    public required string Name { get; set; }
    public CompanyBranchSettingsDto? CompanyBranchSettings { get; set; }
    public AddressDto? Address { get; set; }
    public List<EmployeeDto> Employees { get; set; } = new();
}