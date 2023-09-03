using Schedulify.Domain.Dtos.Base;
using Schedulify.Domain.Dtos.Employees;

namespace Schedulify.Domain.Dtos.Schedules;

public class EmployeeAvailabilityDto : Dto
{
    public DateTime StartDateUtc { get; set; }
    public DateTime? EndDateUtc { get; set; }
    public required EmployeeDto Employee { get; set; }
}