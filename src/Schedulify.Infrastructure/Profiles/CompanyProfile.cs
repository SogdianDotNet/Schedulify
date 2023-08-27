using AutoMapper;
using Schedulify.Domain.Dtos.Companies;
using Schedulify.Infrastructure.Data.Entities.Companies;

namespace Schedulify.Infrastructure.Profiles;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<Company, CompanyDto>();
    }
}