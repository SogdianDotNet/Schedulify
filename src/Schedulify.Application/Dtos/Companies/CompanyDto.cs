using Schedulify.Application.Dtos.Base;

namespace Schedulify.Application.Dtos.Companies;

public class CompanyDto : Dto
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
    public CompanySettingsDto? CompanySettings { get; set; }
}