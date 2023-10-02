using AutoMapper;
using Schedulify.Application.Dtos.Schedules;
using Schedulify.Application.Exceptions;
using Schedulify.Application.Interfaces;
using Schedulify.Domain.Entities.Schedules;

namespace Schedulify.Application.Services;

internal class ScheduleService
{
    private readonly IUserRepository _userRepository;
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ScheduleService(IUserRepository userRepository, IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userRepository = userRepository;
        _appointmentRepository = appointmentRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task CreateAppointmentAsync(AppointmentDto dto, CancellationToken cancellationToken = default)
    {
        var isAvailable = await _appointmentRepository.IsTimePeriodAvailableAsync(dto!.Employee!.Id, dto.StartDateTimeUtc,
            dto.EndDateTimeUtc, cancellationToken);

        if (!isAvailable)
        {
            throw new SException();
        }

        dto.Employee = null;
        dto.AppointmentType = null;
        await _appointmentRepository.AddAsync(_mapper.Map<Appointment>(dto), cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAppointmentAsync(AppointmentDto dto, CancellationToken cancellationToken = default)
    {
        var isAvailable = await _appointmentRepository.IsOtherTimePeriodAvailableAsync(dto!.Employee!.Id, dto.Id,
            dto.StartDateTimeUtc, dto.EndDateTimeUtc, cancellationToken);

        if (!isAvailable)
        {
            throw new SException();
        }

        dto.Employee = null;
        dto.AppointmentType = null;
        _appointmentRepository.Update(_mapper.Map<Appointment>(dto), cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid appointmentId, CancellationToken cancellationToken = default)
    {
        await _appointmentRepository.DeleteAsync(appointmentId, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}