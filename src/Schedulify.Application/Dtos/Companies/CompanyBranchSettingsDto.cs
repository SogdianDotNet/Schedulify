using Schedulify.Application.Dtos.Base;

namespace Schedulify.Application.Dtos.Companies;

public class CompanyBranchSettingsDto : Dto
{
    public int DaysBeforeCancellation { get; set; }
    public int HoursBeforeCancellation { get; set; }
    public int MinutesBeforeCancellation { get; set; }
}