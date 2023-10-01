namespace Schedulify.Application.Interfaces;

internal interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
