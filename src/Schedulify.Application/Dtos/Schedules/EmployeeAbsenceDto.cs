using Schedulify.Application.Dtos.Base;
using Schedulify.Application.Dtos.Employees;
using Schedulify.Domain.Enums;

namespace Schedulify.Application.Dtos.Schedules;

public class EmployeeAbsenceDto : Dto
{
    public DateTime StartDateUtc { get; set; }
    public DateTime? EndDateUtc { get; set; }
    public bool IsApproved { get; set; }
    public required AbsenceType AbsenceType { get; set; }
    public required EmployeeDto Employee { get; set; }
}