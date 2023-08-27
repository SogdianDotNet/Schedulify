using Schedulify.Infrastructure.Data.Entities.Base;
using Schedulify.Infrastructure.Data.Entities.Employees;

namespace Schedulify.Infrastructure.Data.Entities.Common;

internal class Nationality : Entity
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public virtual ICollection<Employee>? Employees { get; set; }
}