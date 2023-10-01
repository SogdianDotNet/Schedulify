using Schedulify.Application.Dtos.Base;

namespace Schedulify.Application.Dtos.Contracts;

public class ContractDto : Dto
{
    public bool IsSignedByEmployee { get; set; }
    public DateTime? DateSignedByEmployee { get; set; }
    public bool IsSignedByEmployer { get; set; }
    public DateTime? DateSignedByEmployer { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}