using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Schedulify.Application.Interfaces;
using Schedulify.Domain.Entities.Schedules;
using Schedulify.Infrastructure.Data;

namespace Schedulify.Infrastructure.Repositories;

internal class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
{
    private readonly IMapper _mapper;

    public AppointmentRepository(SchedulifyDbContext dbContext, IMapper mapper) 
        : base(dbContext)
    {
        _mapper = mapper;
    }

    public Task<Appointment> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _dbContext.Appointments
            .Include(x => x.AppointmentType)
            .ThenInclude(x => x.Prices)
            .Include(x => x.Employee)
            .AsNoTracking()
            .SingleAsync(x => x.Id == id, cancellationToken);
    }

    public Task<bool> IsTimePeriodAvailableAsync(Guid employeeId, DateTime startDateTime, DateTime endDateTime,
        CancellationToken cancellationToken = default)
    {
        return _dbContext.Appointments
            .Include(x => x.Employee)
            .AsNoTracking()
            .AnyAsync(x => x.Employee.Id == employeeId &&
                           (startDateTime >= x.StartDateTimeUtc && startDateTime <= x.EndDateTimeUtc ||
                            endDateTime >= x.StartDateTimeUtc && endDateTime <= x.EndDateTimeUtc), cancellationToken);
    }

    public Task<bool> IsOtherTimePeriodAvailableAsync(Guid employeeId, 
        Guid existingAppointmentId, DateTime startDateTime, DateTime endDateTime,
        CancellationToken cancellationToken = default)
    {
        return _dbContext.Appointments
            .Include(x => x.Employee)
            .AsNoTracking()
            .AnyAsync(x => x.Employee.Id == employeeId && x.Id != existingAppointmentId &&
                           (startDateTime >= x.StartDateTimeUtc && startDateTime <= x.EndDateTimeUtc ||
                            endDateTime >= x.StartDateTimeUtc && endDateTime <= x.EndDateTimeUtc), cancellationToken);
    }

    public async Task AddAsync(Appointment appointment, CancellationToken cancellationToken = default)
    {
        await _dbContext.Appointments.AddAsync(appointment, cancellationToken);
    }

    public void Update(Appointment appointment, CancellationToken cancellationToken = default)
    {
        _dbContext.Appointments.Update(appointment);
    }

    public async Task DeleteAsync(Guid appointmentId, CancellationToken cancellationToken = default)
    {
        var appointment = await _dbContext.Appointments.AsNoTracking()
            .SingleAsync(x => x.Id == appointmentId, cancellationToken);

        _dbContext.Appointments.Remove(appointment);
    }
}