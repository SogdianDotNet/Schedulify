using Schedulify.Infrastructure.Data.Entities.Base;
using Schedulify.Infrastructure.Data.Entities.Employees;

namespace Schedulify.Infrastructure.Data.Entities.Schedules;

internal class Appointment : BaseEntity
{
    public DateTime StartDateTimeUtc { get; set; }
    public DateTime EndDateTimeUtc { get; set; }
    public bool IsCanceled { get; set; }
    public DateTime? CancellationDateTimeUtc { get; set; }
    public virtual required Employee Employee { get; set; }
    public virtual required AppointmentType AppointmentType { get; set; }
}