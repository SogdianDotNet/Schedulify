using Schedulify.Domain.Enums;
using Schedulify.Infrastructure.Data.Entities.Base;
using Schedulify.Infrastructure.Data.Entities.Employees;

namespace Schedulify.Infrastructure.Data.Entities.Schedules;

internal class EmployeeAbsence : BaseEntity
{
    public DateTime StartDateUtc { get; set; }
    public DateTime? EndDateUtc { get; set; }
    public bool IsApproved { get; set; }
    public required AbsenceType AbsenceType { get; set; }
    public virtual required Employee Employee { get; set; }
}