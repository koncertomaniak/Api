using Koncertomaniak.Api.Module.Event.Infrastructure.Dal.Repositories;
using Lamar;

namespace Koncertomaniak.Api.Module.Event.Infrastructure.Dal;

public class EventUnitOfWork : IEventUnitOfWork, IDisposable
{
    private readonly EventDbContext _dbContext;

    public EventUnitOfWork(EventDbContext dbContext)
    {
        _dbContext = dbContext;
        EventRepository = new EventRepository(dbContext);
    }

    public async Task CommitChanges()
    {
        await _dbContext.SaveChangesAsync();
    }

    public IEventRepository EventRepository { get; }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}