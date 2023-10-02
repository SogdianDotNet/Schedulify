using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Schedulify.Domain.Entities.Employees;
using Schedulify.Infrastructure.Data;

namespace Schedulify.Infrastructure.Repositories;

internal class EmployeeRepository : Repository<Employee>
{
    private readonly IMapper _mapper;

    public EmployeeRepository(SchedulifyDbContext dbContext, IMapper mapper)
        : base(dbContext)
    {
        _mapper = mapper;
    }

    public Task<Employee> GetEmployeeAsync(Guid employeeId, CancellationToken cancellationToken = default)
    {
        return _dbContext.Employees
            .Include(x => x.EmployeeAvailabilities)
            .Include(x => x.EmployeeAbsences)
            .AsNoTracking()
            .SingleAsync(x => x.Id == employeeId, cancellationToken);
    }
}