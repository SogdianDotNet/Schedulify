namespace Schedulify.Application.Dtos.Users;

public class CreateUserDto
{
    public required string Email { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public string? PhoneNumber { get; set; }
    public required string[] Roles { get; set; }
    public required Guid CompanyId { get; set; }
}