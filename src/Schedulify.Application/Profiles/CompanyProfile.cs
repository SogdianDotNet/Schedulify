using AutoMapper;
using Schedulify.Application.Dtos.Companies;
using Schedulify.Domain.Entities.Companies;

namespace Schedulify.Application.Profiles;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<Company, CompanyDto>();
    }
}