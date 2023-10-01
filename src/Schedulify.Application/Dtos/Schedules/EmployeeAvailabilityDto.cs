using Schedulify.Application.Dtos.Base;
using Schedulify.Application.Dtos.Employees;

namespace Schedulify.Application.Dtos.Schedules;

public class EmployeeAvailabilityDto : Dto
{
    public DateTime StartDateUtc { get; set; }
    public DateTime? EndDateUtc { get; set; }
    public required EmployeeDto Employee { get; set; }
}