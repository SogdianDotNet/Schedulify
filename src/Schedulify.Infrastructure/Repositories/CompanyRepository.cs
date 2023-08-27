using System.Linq.Expressions;
using AutoMapper;
using Schedulify.Application.Interfaces;
using Schedulify.Domain.Dtos.Companies;
using Schedulify.Infrastructure.Data;
using Schedulify.Infrastructure.Data.Entities.Companies;

namespace Schedulify.Infrastructure.Repositories;

internal class CompanyRepository : Repository<Company>, ICompanyRepository
{
    private readonly IMapper _mapper;

    public CompanyRepository(SchedulifyDbContext dbContext, IMapper mapper) 
        : base(dbContext)
    {
        _mapper = mapper;
    }

    public new async Task<CompanyDto?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _mapper.Map<CompanyDto>(await base.GetAsync(id, cancellationToken));
    }

    public new async Task<IReadOnlyCollection<CompanyDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _mapper.Map<IReadOnlyCollection<CompanyDto>>(await base.GetAllAsync(cancellationToken));
    }

    public async Task<CompanyDto> CreateAsync(CompanyDto dto, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<Company>(dto);

        List<Expression<Func<Company, object>>> includes = new()
        {
            x => x.CompanySettings,
            x => x.CompanyBranches
        };
        
        return _mapper.Map<CompanyDto>(await base.CreateAsync(entity, includes, cancellationToken));
    }

    public async Task<CompanyDto> UpdateAsync(CompanyDto dto, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<Company>(dto);
        
        return _mapper.Map<CompanyDto>(await base.UpdateAsync(entity, null, cancellationToken));
    }

    public async Task BlockAsync(Guid companyId, DateTime? startDate, DateTime? endDate,
        CancellationToken cancellationToken = default)
    {
        var entity = await base.GetAsync(companyId, cancellationToken);
        
        ArgumentNullException.ThrowIfNull(entity);

        entity.IsBlocked = true;
        entity.StartDateTimeBlockedUtc = startDate;
        entity.EndDateTimeBlockedUtc = endDate;
        await base.UpdateAsync(entity, null, cancellationToken);
    }

    public async Task UnblockAsync(Guid companyId, CancellationToken cancellationToken = default)
    {
        var entity = await base.GetAsync(companyId, cancellationToken);
        
        ArgumentNullException.ThrowIfNull(entity);

        entity.IsBlocked = false;
        entity.StartDateTimeBlockedUtc = null;
        entity.EndDateTimeBlockedUtc = null;
        await base.UpdateAsync(entity, null, cancellationToken);
    }
}