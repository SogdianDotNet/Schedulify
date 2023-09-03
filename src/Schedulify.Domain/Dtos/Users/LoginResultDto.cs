using Schedulify.Domain.Dtos.Users.Enums;

namespace Schedulify.Domain.Dtos.Users;

public class LoginResultDto
{
    public required TokenDto? Token { get; set; }
    public required LoginResult Result { get; set; }
}