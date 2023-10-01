using Schedulify.Domain.Entities.Base;
using Schedulify.Domain.Entities.Employees;

namespace Schedulify.Domain.Entities.Contracts;

internal class Contract : Entity
{
    public bool IsSignedByEmployee { get; set; }
    public DateTime? DateSignedByEmployee { get; set; }
    public bool IsSignedByEmployer { get; set; }
    public DateTime? DateSignedByEmployer { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public virtual required Employee Employee { get; set; }
}