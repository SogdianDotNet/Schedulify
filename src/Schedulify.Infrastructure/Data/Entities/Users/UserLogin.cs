using Microsoft.AspNetCore.Identity;
using Schedulify.Infrastructure.Data.Attributes;

namespace Schedulify.Infrastructure.Data.Entities.Users;

[DisableAudit]
internal class UserLogin : IdentityUserLogin<Guid>
{
    public virtual User User { get; set; }
}