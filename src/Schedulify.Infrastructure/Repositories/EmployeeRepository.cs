using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Schedulify.Application.Dtos.Employees;
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

    public async Task<EmployeeDto> GetEmployeeAsync(Guid employeeId,
        CancellationToken cancellationToken = default)
    {
        var employee = await _dbContext.Employees
            .Include(x => x.EmployeeAvailabilities)
            .Include(x => x.EmployeeAbsences)
            .AsNoTracking()
            .SingleAsync(x => x.Id == employeeId, cancellationToken);

        return _mapper.Map<EmployeeDto>(employee);
    }
}