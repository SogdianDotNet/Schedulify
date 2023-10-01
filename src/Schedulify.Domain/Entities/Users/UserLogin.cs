using Microsoft.AspNetCore.Identity;
using Schedulify.Domain.Attributes;

namespace Schedulify.Domain.Entities.Users;

[DisableAudit]
internal class UserLogin : IdentityUserLogin<Guid>
{
    public virtual User User { get; set; }
}