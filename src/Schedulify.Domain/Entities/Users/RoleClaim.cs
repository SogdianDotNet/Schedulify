using Microsoft.AspNetCore.Identity;
using Schedulify.Domain.Attributes;

namespace Schedulify.Domain.Entities.Users;

[DisableAudit]
internal class RoleClaim : IdentityRoleClaim<Guid>
{
    public virtual Role Role { get; set; }
}