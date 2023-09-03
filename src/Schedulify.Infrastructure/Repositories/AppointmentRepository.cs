using AutoMapper;
using Schedulify.Infrastructure.Data;
using Schedulify.Infrastructure.Data.Entities.Schedules;

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