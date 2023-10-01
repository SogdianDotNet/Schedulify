using Schedulify.Application.Dtos.Base;

namespace Schedulify.Application.Dtos.Companies;

public class CompanySettingsDto : Dto
{
    public int MaximumBranches { get; set; }
}