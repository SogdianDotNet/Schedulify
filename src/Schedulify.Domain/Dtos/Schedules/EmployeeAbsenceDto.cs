using Schedulify.Domain.Dtos.Base;
using Schedulify.Domain.Dtos.Employees;
using Schedulify.Domain.Enums;

namespace Schedulify.Domain.Dtos.Schedules;

public class EmployeeAbsenceDto : Dto
{
    public DateTime StartDateUtc { get; set; }
    public DateTime? EndDateUtc { get; set; }
    public bool IsApproved { get; set; }
    public required AbsenceType AbsenceType { get; set; }
    public required EmployeeDto Employee { get; set; }
}