using Microsoft.AspNetCore.Identity;
using Schedulify.Infrastructure.Data.Attributes;

namespace Schedulify.Infrastructure.Data.Entities.Users;

[DisableAudit]
public class UserToken : IdentityUserToken<Guid>
{
    public virtual User User { get; set; }
}
