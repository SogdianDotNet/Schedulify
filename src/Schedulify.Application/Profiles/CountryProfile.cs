using AutoMapper;
using Schedulify.Application.Dtos.Base;
using Schedulify.Domain.Entities.Common;

namespace Schedulify.Application.Profiles;

internal class CountryProfile : Profile
{
    public CountryProfile()
    {
        CreateMap<Country, CountryDto>();
        CreateMap<CountryDto, Country>();
    }
}