using Schedulify.Domain.Dtos.Base;

namespace Schedulify.Domain.Dtos.Companies;

public class CompanyBranchSettingsDto : Dto
{
    public int DaysBeforeCancellation { get; set; }
    public int HoursBeforeCancellation { get; set; }
    public int MinutesBeforeCancellation { get; set; }
}