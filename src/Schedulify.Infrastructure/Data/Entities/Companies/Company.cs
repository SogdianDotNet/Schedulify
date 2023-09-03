using System.Collections;
using Schedulify.Infrastructure.Data.Entities.Base;
using Schedulify.Infrastructure.Data.Entities.Users;

namespace Schedulify.Infrastructure.Data.Entities.Companies;

internal class Company : Entity
{
    public required string Name { get; set; }
    public required string Website { get; set; }
    public required string LegalStructure { get; set; }
    public required string CoCNumber { get; set; }
    public required string Email { get; set; }
    public required string Description { get; set; }
    public bool IsBlocked { get; set; }
    public DateTime? StartDateTimeBlockedUtc { get; set; }
    public DateTime? EndDateTimeBlockedUtc { get; set; }
    public virtual required CompanySettings CompanySettings { get; set; }
    public virtual ICollection<CompanyBranch>? CompanyBranches { get; set; }
    public virtual ICollection<User>? Users { get; set; }
}