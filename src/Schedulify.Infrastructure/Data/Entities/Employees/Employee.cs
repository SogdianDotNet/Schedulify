using Schedulify.Infrastructure.Data.Entities.Companies;
using Schedulify.Infrastructure.Data.Entities.Base;
using Schedulify.Infrastructure.Data.Entities.Common;
using Schedulify.Infrastructure.Data.Entities.Contracts;
using Schedulify.Infrastructure.Data.Entities.Schedules;

namespace Schedulify.Infrastructure.Data.Entities.Employees;

internal class Employee : Entity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Function { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime ActiveFromUtc { get; set; }
    public DateTime? ActiveToUtc { get; set; }
    public virtual required ICollection<Nationality> Nationalities { get; set; }
    public virtual ICollection<Contract>? Contracts { get; set; }
    public virtual ICollection<CompanyBranchEmployee>? CompanyBranchEmployees { get; set; }
    public virtual ICollection<EmployeeAvailability>? EmployeeAvailabilities { get; set; }
    public virtual ICollection<EmployeeAbsence>? EmployeeAbsences { get; set; }
    public virtual ICollection<Appointment>? Appointments { get; set; }
}
