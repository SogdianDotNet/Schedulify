using Schedulify.Domain.Dtos.Base;
using Schedulify.Domain.Dtos.Companies;

namespace Schedulify.Domain.Dtos.Users;

public class UserDto : Dto
{
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public string? UserName { get; set; }
    public string? NormalizedUserName { get; set; }
    public string? Email { get; set; }
    public string? NormalizedEmail { get; set; }
    public bool EmailConfirmed { get; set; }
    public string? SecurityStamp { get; set; }
    public string? PhoneNumber { get; set; }
    public bool PhoneNumberConfirmed { get; set; }
    public bool TwoFactorEnabled { get; set; }
    public DateTimeOffset? LockoutEnd { get; set; }
    public bool LockoutEnabled { get; set; }
    public int AccessFailedCount { get; set; }
    public bool IsAllowedToLogin { get; set; }
    public DateTime? LastAccessFailedUtc { get; set; }
    public string[] Roles { get; set; } = Array.Empty<string>();
    
    public CompanyDto? Company { get; set; }
}