using Schedulify.Domain.Entities.Schedules;

namespace Schedulify.Application.Interfaces;

internal interface IAppointmentRepository
{
    Task<Appointment> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> IsTimePeriodAvailableAsync(
        Guid employeeId,
        DateTime startDateTime, DateTime endDateTime,
        CancellationToken cancellationToken = default);

    Task<bool> IsOtherTimePeriodAvailableAsync(Guid employeeId,
        Guid existingAppointmentId, DateTime startDateTime, DateTime endDateTime,
        CancellationToken cancellationToken = default);

    Task AddAsync(Appointment appointment, CancellationToken cancellationToken = default);
    void Update(Appointment appointment, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid appointmentId, CancellationToken cancellationToken = default);
}
