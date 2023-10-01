using Schedulify.Domain.Entities.Companies;

namespace Schedulify.Application.Interfaces;

internal interface ICompanyRepository
{
    Task<Company?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Company> CreateAsync(Company company, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Company>> GetAllAsync(CancellationToken cancellationToken = default);
    Task BlockAsync(Guid companyId, DateTime? startDate, DateTime? endDate,
        CancellationToken cancellationToken = default);
    Task UnblockAsync(Guid companyId, CancellationToken cancellationToken = default);
}