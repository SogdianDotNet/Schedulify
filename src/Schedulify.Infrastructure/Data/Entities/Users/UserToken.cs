using Microsoft.AspNetCore.Identity;
using Schedulify.Infrastructure.Data.Attributes;

namespace Schedulify.Infrastructure.Data.Entities.Users;

[DisableAudit]
internal class UserToken : IdentityUserToken<Guid>
{
    public virtual User User { get; set; }
}
