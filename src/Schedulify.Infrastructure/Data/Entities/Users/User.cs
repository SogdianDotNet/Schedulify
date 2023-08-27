using Microsoft.AspNetCore.Identity;
using Schedulify.Infrastructure.Data.Attributes;

namespace Schedulify.Infrastructure.Data.Entities.Users;

[DisableAudit]
public class User : IdentityUser<Guid>
{
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
}