using Microsoft.AspNetCore.Identity;

namespace Schedulify.Domain.Entities.Users;

internal class Role : IdentityRole<Guid>
{
    public virtual ICollection<UserRole> UserRoles { get; set; }
    public virtual ICollection<RoleClaim> RoleClaims { get; set; }
}