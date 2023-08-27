using AutoMapper;
using Schedulify.Domain.Dtos.Base;
using Schedulify.Infrastructure.Data.Entities.Common;

namespace Schedulify.Infrastructure.Profiles;

internal class CountryProfile : Profile
{
    public CountryProfile()
    {
        CreateMap<Country, CountryDto>();
        CreateMap<CountryDto, Country>();
    }
}