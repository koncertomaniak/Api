using Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal.Repositories;

namespace Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal;

public class TicketUnitOfWork : ITicketUnitOfWork, IDisposable
{
    private readonly TicketDbContext _dbContext;
    public ITicketRepository TicketRepository { get; }
    public ITicketProviderRepository TicketProviderRepository { get; }
    
    public TicketUnitOfWork(TicketDbContext dbContext)
    {
        _dbContext = dbContext;
        TicketRepository = new TicketRepository(dbContext);
        TicketProviderRepository = new TicketProviderRepository(dbContext);
    }

    public async Task CommitChanges()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}