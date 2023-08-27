using Schedulify.Domain.Dtos.Companies;

namespace Schedulify.Application.Interfaces;

public interface ICompanySettingsRepository
{
    Task<CompanySettingsDto> GetByCompanyIdAsync(Guid companyId, CancellationToken cancellationToken = default);
    Task<CompanySettingsDto> UpdateAsync(CompanySettingsDto dto, CancellationToken cancellationToken = default);
}