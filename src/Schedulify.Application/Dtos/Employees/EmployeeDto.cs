using Schedulify.Application.Dtos.Base;
using Schedulify.Application.Dtos.Common;
using Schedulify.Application.Dtos.Companies;
using Schedulify.Application.Dtos.Contracts;
using Schedulify.Application.Dtos.Schedules;

namespace Schedulify.Application.Dtos.Employees;

public class EmployeeDto : Dto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Function { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime ActiveFromUtc { get; set; }
    public DateTime? ActiveToUtc { get; set; }
    public List<NationalityDto> Nationalities { get; set; } = new();
    public List<ContractDto>? Contracts { get; set; } = new();
    public List<CompanyBranchDto>? CompanyBranches { get; set; } = new();
    public virtual ICollection<EmployeeAvailabilityDto>? EmployeeAvailabilities { get; set; }
    public virtual ICollection<EmployeeAbsenceDto>? EmployeeAbsences { get; set; }
    public virtual ICollection<AppointmentDto>? Appointments { get; set; }
}