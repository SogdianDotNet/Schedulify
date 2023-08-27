using Microsoft.AspNetCore.Identity;
using Schedulify.Infrastructure.Data.Attributes;

namespace Schedulify.Infrastructure.Data.Entities.Users;

[DisableAudit]
public class UserRole : IdentityUserRole<Guid>
{
    public virtual User User { get; set; }
    public virtual Role Role { get; set; }
}