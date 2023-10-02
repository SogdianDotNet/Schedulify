using Schedulify.Application.Dtos.Base;
using Schedulify.Application.Dtos.Employees;

namespace Schedulify.Application.Dtos.Schedules;

public class AppointmentDto : Dto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Comment { get; set; }
    public DateTime StartDateTimeUtc { get; set; }
    public DateTime EndDateTimeUtc { get; set; }
    public bool IsCanceled { get; set; }
    public DateTime? CancellationDateTimeUtc { get; set; }
    public required Guid EmployeeId { get; set; }
    public required Guid AppointmentTypeId { get; set; }
    public EmployeeDto? Employee { get; set; }
    public AppointmentTypeDto? AppointmentType { get; set; }
}