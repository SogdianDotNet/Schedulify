using AutoMapper;
using Schedulify.Application.Dtos.Companies;
using Schedulify.Application.Interfaces;
using Schedulify.Domain.Entities.Companies;

namespace Schedulify.Application.Services;

internal sealed class CompanyService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICompanyRepository _companyRepository;
    private readonly ICompanySettingsRepository _companySettingsRepository;
    private readonly IMapper _mapper;

    public CompanyService(
        IUnitOfWork unitOfWork,
        ICompanyRepository companyRepository,
        ICompanySettingsRepository companySettingsRepository, 
        IMapper mapper)
    {
        _companyRepository = companyRepository;
        _companySettingsRepository = companySettingsRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<CompanyDto> CreateAsync(CompanyDto dto, CancellationToken cancellationToken = default)
    {
        var company = await _companyRepository.CreateAsync(_mapper.Map<Company>(dto), cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CompanyDto>(company);
    }
}