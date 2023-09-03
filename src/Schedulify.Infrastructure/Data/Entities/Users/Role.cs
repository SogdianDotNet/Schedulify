using Microsoft.AspNetCore.Identity;

namespace Schedulify.Infrastructure.Data.Entities.Users;

internal class Role : IdentityRole<Guid>
{
    public virtual ICollection<UserRole> UserRoles { get; set; }
    public virtual ICollection<RoleClaim> RoleClaims { get; set; }
}