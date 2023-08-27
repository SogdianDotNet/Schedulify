using Schedulify.Infrastructure.Data.Entities.Base;
using Schedulify.Infrastructure.Data.Entities.Employees;

namespace Schedulify.Infrastructure.Data.Entities.Contracts;

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