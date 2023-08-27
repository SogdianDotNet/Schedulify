using System.Linq.Expressions;
using AutoMapper;
using Schedulify.Domain.Dtos.Companies;
using Schedulify.Infrastructure.Data;
using Schedulify.Infrastructure.Data.Entities.Companies;

namespace Schedulify.Infrastructure.Repositories;

public interface ICompanyRepository
{
    new Task<CompanyDto?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<CompanyDto> CreateAsync(CompanyDto dto, CancellationToken cancellationToken = default);
}

internal class CompanyRepository : Repository<Company>
{
    private readonly IMapper _mapper;

    public CompanyRepository(SchedulifyDbContext dbContext, IMapper mapper) : base(dbContext)
    {
        _mapper = mapper;
    }

    public new async Task<CompanyDto?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _mapper.Map<CompanyDto>(await base.GetAsync(id, cancellationToken));
    }

    public async Task<CompanyDto> CreateAsync(CompanyDto dto, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<Company>(dto);

        List<Expression<Func<Company, object>>> includes = new List<Expression<Func<Company, object>>>
        {
            x => x.CompanySettings,
            x => x.CompanyBranches
        };
        return _mapper.Map<CompanyDto>(await base.CreateAsync(entity, includes, cancellationToken));
    }
}