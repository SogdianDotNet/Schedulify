using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Schedulify.Application.Interfaces;
using Schedulify.Domain.Dtos.Companies;
using Schedulify.Infrastructure.Data;
using Schedulify.Infrastructure.Data.Entities.Companies;

namespace Schedulify.Infrastructure.Repositories;

internal class CompanySettingsRepository : Repository<CompanySettings>, ICompanySettingsRepository
{
    private readonly IMapper _mapper;

    public CompanySettingsRepository(SchedulifyDbContext dbContext, IMapper mapper) : base(dbContext)
    {
        _mapper = mapper;
    }

    public async Task<CompanySettingsDto> GetByCompanyIdAsync(Guid companyId, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.CompanySettings
            .AsNoTracking()
            .Include(x => x.Company)
            .SingleAsync(x => x.Company.Id == companyId, cancellationToken);

        return _mapper.Map<CompanySettingsDto>(entity);
    }

    public async Task<CompanySettingsDto> UpdateAsync(CompanySettingsDto dto, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<CompanySettings>(dto);
        
        return _mapper.Map<CompanySettingsDto>(await base.UpdateAsync(entity, null, cancellationToken));
    }
}