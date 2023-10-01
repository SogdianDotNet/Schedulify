using Schedulify.Domain.Entities.Base;
using Schedulify.Domain.Entities.Employees;
using Schedulify.Domain.Enums;

namespace Schedulify.Domain.Entities.Schedules;

internal class EmployeeAbsence : Entity
{
    public DateTime StartDateUtc { get; set; }
    public DateTime? EndDateUtc { get; set; }
    public bool IsApproved { get; set; }
    public required AbsenceType AbsenceType { get; set; }
    public virtual required Employee Employee { get; set; }
}