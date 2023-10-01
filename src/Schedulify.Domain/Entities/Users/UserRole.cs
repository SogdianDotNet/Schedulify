using Microsoft.AspNetCore.Identity;
using Schedulify.Domain.Attributes;

namespace Schedulify.Domain.Entities.Users;

[DisableAudit]
internal class UserRole : IdentityUserRole<Guid>
{
    public virtual User User { get; set; }
    public virtual Role Role { get; set; }
}