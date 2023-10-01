using Schedulify.Domain.Entities.Base;

namespace Schedulify.Domain.Entities.Companies;

internal class CompanyBranchSettings : Entity
{
    public int DaysBeforeCancellation { get; set; }
    public int HoursBeforeCancellation { get; set; }
    public int MinutesBeforeCancellation { get; set; }
    public virtual required CompanyBranch CompanyBranch { get; set; }
}