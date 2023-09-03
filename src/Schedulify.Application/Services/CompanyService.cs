using Schedulify.Application.Interfaces;
using Schedulify.Domain.Dtos.Companies;

namespace Schedulify.Application.Services;

public sealed class CompanyService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly ICompanySettingsRepository _companySettingsRepository;

    public CompanyService(
        ICompanyRepository companyRepository,
        ICompanySettingsRepository companySettingsRepository)
    {
        _companyRepository = companyRepository;
        _companySettingsRepository = companySettingsRepository;
    }

    public async Task<CompanyDto> CreateAsync(CompanyDto dto, CancellationToken cancellationToken = default)
    {
        var company = await _companyRepository.CreateAsync(dto, cancellationToken);

        return company;
    }
}