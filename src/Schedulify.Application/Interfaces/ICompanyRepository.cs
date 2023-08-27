using Schedulify.Domain.Dtos.Companies;

namespace Schedulify.Application.Interfaces;

public interface ICompanyRepository
{
    new Task<CompanyDto?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<CompanyDto> CreateAsync(CompanyDto dto, CancellationToken cancellationToken = default);
    new Task<IReadOnlyCollection<CompanyDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task BlockAsync(Guid companyId, DateTime? startDate, DateTime? endDate,
        CancellationToken cancellationToken = default);
    Task UnblockAsync(Guid companyId, CancellationToken cancellationToken = default);
}