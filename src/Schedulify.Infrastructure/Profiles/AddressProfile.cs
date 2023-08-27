using AutoMapper;
using Schedulify.Domain.Dtos.Common;
using Schedulify.Infrastructure.Data.Entities.Common;

namespace Schedulify.Infrastructure.Profiles;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<Address, AddressDto>(MemberList.Destination);
        CreateMap<AddressDto, Address>();
    }
}