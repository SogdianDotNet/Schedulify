using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Schedulify.Application.Interfaces;
using Schedulify.Domain.Entities.Companies;
using Schedulify.Infrastructure.Data;

namespace Schedulify.Infrastructure.Repositories;

internal class CompanySettingsRepository : Repository<CompanySettings>, ICompanySettingsRepository
{
    private readonly IMapper _mapper;

    public CompanySettingsRepository(SchedulifyDbContext dbContext, IMapper mapper) : base(dbContext)
    {
        _mapper = mapper;
    }

    public async Task<CompanySettings> GetByCompanyIdAsync(Guid companyId, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.CompanySettings
            .AsNoTracking()
            .Include(x => x.Company)
            .SingleAsync(x => x.Company.Id == companyId, cancellationToken);

        return entity;
    }

    public async Task<CompanySettings> UpdateAsync(CompanySettings companySettings, CancellationToken cancellationToken = default)
    {
        return await base.UpdateAsync(companySettings, null, cancellationToken);
    }
}