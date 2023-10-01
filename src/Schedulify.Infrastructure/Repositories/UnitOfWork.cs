using Schedulify.Application.Interfaces;
using Schedulify.Infrastructure.Data;

namespace Schedulify.Infrastructure.Repositories;

internal class UnitOfWork : IUnitOfWork
{
    private readonly SchedulifyDbContext _dbContext;

    public UnitOfWork(SchedulifyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
