namespace Schedulify.Application.Dtos.Users.Enums;

public enum LoginResult
{
    Unknown = 0,
    Locked = 1,
    Banned = 2,
    Deleted = 3,
    EmailUnconfirmed = 4,
    Failed = 5,
    Success = 6
}