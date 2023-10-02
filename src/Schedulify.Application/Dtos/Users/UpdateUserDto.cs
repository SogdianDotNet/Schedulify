namespace Schedulify.Application.Dtos.Users;

public class UpdateUserDto
{
    public required Guid Id { get; set; }
    public required string Email { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public string? PhoneNumber { get; set; }
    public required string[] Roles { get; set; }
}
