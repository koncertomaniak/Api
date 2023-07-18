using Koncertomaniak.Api.Module.Event.Infrastructure.Dal.Repositories;

namespace Koncertomaniak.Api.Module.Event.Infrastructure.Dal;

public class EventUnitOfWork : IEventUnitOfWork, IDisposable
{
    private readonly EventDbContext _dbContext;

    public EventUnitOfWork(EventDbContext dbContext)
    {
        _dbContext = dbContext;
        EventRepository = new EventRepository(dbContext);
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public async Task CommitChanges()
    {
        await _dbContext.SaveChangesAsync();
    }

    public IEventRepository EventRepository { get; }
}