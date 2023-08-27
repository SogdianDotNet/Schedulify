using Schedulify.Infrastructure.Data.Entities.Base;
using Schedulify.Infrastructure.Data.Entities.Finances;

namespace Schedulify.Infrastructure.Data.Entities.Schedules;

internal class AppointmentType : BaseEntity
{
    public required string Name { get; set; }
    public virtual ICollection<Appointment>? Appointments { get; set; }
    public virtual ICollection<Price>? Prices { get; set; }
}