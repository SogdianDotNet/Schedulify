using Schedulify.Domain.Entities.Base;
using Schedulify.Domain.Entities.Employees;

namespace Schedulify.Domain.Entities.Schedules;

internal class Appointment : Entity
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
    public virtual required Employee Employee { get; set; }
    public virtual required AppointmentType AppointmentType { get; set; }
}