using AutoMapper;
using Schedulify.Application.Dtos.Common;
using Schedulify.Domain.Entities.Common;

namespace Schedulify.Application.Profiles;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<Address, AddressDto>(MemberList.Destination);
        CreateMap<AddressDto, Address>();
    }
}