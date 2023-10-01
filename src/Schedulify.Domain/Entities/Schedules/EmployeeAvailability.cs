using Schedulify.Domain.Entities.Base;
using Schedulify.Domain.Entities.Employees;

namespace Schedulify.Domain.Entities.Schedules;

internal class EmployeeAvailability : Entity
{
    public DateTime StartDateUtc { get; set; }
    public DateTime? EndDateUtc { get; set; }
    public virtual required Employee Employee { get; set; }
}