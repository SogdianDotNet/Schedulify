using AutoMapper;
using Schedulify.Domain.Entities.Schedules;
using Schedulify.Infrastructure.Data;

namespace Schedulify.Infrastructure.Repositories;

internal class AppointmentRepository : Repository<Appointment>
{
    private readonly IMapper _mapper;

    public AppointmentRepository(SchedulifyDbContext dbContext, IMapper mapper) 
        : base(dbContext)
    {
        _mapper = mapper;
    }
    
    
}