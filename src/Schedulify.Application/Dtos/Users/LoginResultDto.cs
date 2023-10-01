using Schedulify.Application.Dtos.Users.Enums;

namespace Schedulify.Application.Dtos.Users;

public class LoginResultDto
{
    public required TokenDto? Token { get; set; }
    public required LoginResult Result { get; set; }
}