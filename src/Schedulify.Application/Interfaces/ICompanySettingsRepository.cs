using Schedulify.Domain.Entities.Companies;

namespace Schedulify.Application.Interfaces;

internal interface ICompanySettingsRepository
{
    Task<CompanySettings> GetByCompanyIdAsync(Guid companyId, CancellationToken cancellationToken = default);
    Task<CompanySettings> UpdateAsync(CompanySettings companyompanySettings, CancellationToken cancellationToken = default);
}