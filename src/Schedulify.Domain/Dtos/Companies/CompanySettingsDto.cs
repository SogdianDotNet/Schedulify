using Schedulify.Domain.Dtos.Base;

namespace Schedulify.Domain.Dtos.Companies;

public class CompanySettingsDto : Dto
{
    public int MaximumBranches { get; set; }
}