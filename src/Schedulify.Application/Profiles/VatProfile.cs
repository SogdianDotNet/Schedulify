using AutoMapper;
using Schedulify.Application.Dtos.Vats;
using Schedulify.Domain.Entities.Vats;

namespace Schedulify.Application.Profiles;

public class VatProfile : Profile
{
    public VatProfile()
    {
        CreateMap<VatRate, VatRateDto>();
    }
}