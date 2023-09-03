using AutoMapper;
using Schedulify.Domain.Constants;
using Schedulify.Domain.Dtos.Users;
using Schedulify.Domain.Enums;
using Schedulify.Infrastructure.Data.Entities.Users;

namespace Schedulify.Infrastructure.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<string, ApplicationRole>().ConvertUsing((value, _) =>
        {
            return value switch
            {
                ApplicationRoles.SuperAdmin => ApplicationRole.SuperAdmin,
                ApplicationRoles.Admin => ApplicationRole.Admin,
                ApplicationRoles.CompanyAdmin => ApplicationRole.CompanyAdmin,
                ApplicationRoles.Employee => ApplicationRole.Employee,
                _ => throw new InvalidOperationException()
            };
        });
        CreateMap<ApplicationRole, string>().ConvertUsing((value, _) =>
        {
            return value switch
            {
                ApplicationRole.SuperAdmin => ApplicationRoles.SuperAdmin,
                ApplicationRole.Admin => ApplicationRoles.Admin,
                ApplicationRole.CompanyAdmin => ApplicationRoles.CompanyAdmin,
                ApplicationRole.Employee => ApplicationRoles.Employee
            };
        });
        CreateMap<User, UserDto>()
            .ForMember(d => d.Roles, o => o.MapFrom(s => 
                s.UserRoles != null ? s.UserRoles.Select(ur => ur.Role.Name).ToArray() : Array.Empty<string>()));
        CreateMap<CreateUserDto, User>(MemberList.None);
    }
}