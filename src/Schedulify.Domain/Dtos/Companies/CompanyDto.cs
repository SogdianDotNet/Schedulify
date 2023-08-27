using Schedulify.Domain.Dtos.Base;

namespace Schedulify.Domain.Dtos.Companies;

public class CompanyDto : BaseDto
{
    public required string Name { get; set; }
    public required string Website { get; set; }
    public required string LegalStructure { get; set; }
    public required string CoCNumber { get; set; }
    public required string Email { get; set; }
    public required string Description { get; set; }
}