using Schedulify.Domain.Dtos.Base;

namespace Schedulify.Domain.Dtos.Contracts;

public class ContractDto : Dto
{
    public bool IsSignedByEmployee { get; set; }
    public DateTime? DateSignedByEmployee { get; set; }
    public bool IsSignedByEmployer { get; set; }
    public DateTime? DateSignedByEmployer { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}