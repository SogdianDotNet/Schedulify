using Schedulify.Domain.Entities.Base;
using Schedulify.Domain.Entities.Employees;

namespace Schedulify.Domain.Entities.Common;

internal class Nationality : Entity
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public virtual ICollection<Employee>? Employees { get; set; }
}