using Koncertomaniak.Api.Shared.Infrastructure.Db;

namespace Koncertomaniak.Api.Module.Event.Infrastructure.Dal;

public class EventUnitOfWork : IUnitOfWork
{
    private readonly EventDbContext _dbContext;

    public EventUnitOfWork(EventDbContext eventDbContext)
    {
        _dbContext = eventDbContext;
    }

    public async Task CommitChanges()
    {
        await _dbContext.SaveChangesAsync();
    }
}