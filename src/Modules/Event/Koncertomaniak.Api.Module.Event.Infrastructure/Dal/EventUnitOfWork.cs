using Lamar;

namespace Koncertomaniak.Api.Module.Event.Infrastructure.Dal;

public class EventUnitOfWork : IEventUnitOfWork
{
    private readonly EventDbContext _dbContext;

    public EventUnitOfWork(IContainer container)
    {
        var dbContext = container.GetInstance<EventDbContext>();
        _dbContext = dbContext;
    }

    public async Task CommitChanges()
    {
        await _dbContext.SaveChangesAsync();
    }
}