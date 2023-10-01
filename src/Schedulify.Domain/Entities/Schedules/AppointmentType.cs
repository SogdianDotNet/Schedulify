using Schedulify.Domain.Entities.Base;
using Schedulify.Domain.Entities.Finances;

namespace Schedulify.Domain.Entities.Schedules;

internal class AppointmentType : Entity
{
    public required string Name { get; set; }
    public virtual ICollection<Appointment>? Appointments { get; set; }
    public virtual ICollection<Price>? Prices { get; set; }
}