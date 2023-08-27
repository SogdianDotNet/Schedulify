using System.Linq.Expressions;
using Schedulify.Infrastructure.Data.Entities.Base;

namespace Schedulify.Infrastructure.Repositories;

internal interface IRepository<T> where T : Entity
{
    Task<T?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<T>> GetAll(CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<T>> FindAsync(Expression<Func<T, bool>>? expression, CancellationToken cancellationToken = default);
    Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);
    Task<T> CreateAsync(T entity, List<Expression<Func<T, object>>>? includes = null, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<T>> CreateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    Task<T> UpdateAsync(T entity, List<Expression<Func<T, object>>>? includes = null, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<T>> UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteRangeAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
    Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
}