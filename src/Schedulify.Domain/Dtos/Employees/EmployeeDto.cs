using Schedulify.Domain.Dtos.Base;
using Schedulify.Domain.Dtos.Common;
using Schedulify.Domain.Dtos.Companies;
using Schedulify.Domain.Dtos.Contracts;

namespace Schedulify.Domain.Dtos.Employees;

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
    //public virtual ICollection<EmployeeAvailability>? EmployeeAvailabilities { get; set; }
    //public virtual ICollection<EmployeeAbsence>? EmployeeAbsences { get; set; }
    //public virtual ICollection<Appointment>? Appointments { get; set; }
}