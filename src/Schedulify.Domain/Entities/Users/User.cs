using Microsoft.AspNetCore.Identity;
using Schedulify.Domain.Attributes;
using Schedulify.Domain.Entities.Base;
using Schedulify.Domain.Entities.Companies;

namespace Schedulify.Domain.Entities.Users;

[DisableAudit]
internal class User : IdentityUser<Guid>, IEntity, ISoftDeleteEntity
{
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public bool IsAllowedToLogin { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? LastAccessFailedUtc { get; set; }
    public DateTime? DeletedOnUtc { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
    public Guid? CompanyId { get; set; }
    public virtual Company? Company { get; set; }
    public virtual ICollection<UserRole>? UserRoles { get; set; }
    public virtual ICollection<UserClaim>? Claims { get; set; }
    public virtual ICollection<UserLogin>? Logins { get; set; }
    public virtual ICollection<UserToken>? Tokens { get; set; }
}