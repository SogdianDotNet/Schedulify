using Microsoft.AspNetCore.Identity;
using Schedulify.Infrastructure.Data.Attributes;

namespace Schedulify.Infrastructure.Data.Entities.Users;

[DisableAudit]
internal class RoleClaim : IdentityRoleClaim<Guid>
{
    public virtual Role Role { get; set; }
}