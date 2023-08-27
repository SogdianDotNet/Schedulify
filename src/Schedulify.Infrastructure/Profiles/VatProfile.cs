using AutoMapper;
using Schedulify.Domain.Dtos.Vats;
using Schedulify.Infrastructure.Data.Entities.Vats;

namespace Schedulify.Infrastructure.Profiles;

public class VatProfile : Profile
{
    public VatProfile()
    {
        CreateMap<VatRate, VatRateDto>();
    }
}