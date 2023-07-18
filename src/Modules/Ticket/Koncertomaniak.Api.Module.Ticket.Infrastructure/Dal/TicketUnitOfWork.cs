using Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal.Repositories;

namespace Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal;

public class TicketUnitOfWork : ITicketUnitOfWork, IDisposable
{
    private readonly TicketDbContext _dbContext;

    public TicketUnitOfWork(TicketDbContext dbContext)
    {
        _dbContext = dbContext;
        TicketRepository = new TicketRepository(dbContext);
        TicketProviderRepository = new TicketProviderRepository(dbContext);
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public ITicketRepository TicketRepository { get; }
    public ITicketProviderRepository TicketProviderRepository { get; }

    public async Task CommitChanges()
    {
        await _dbContext.SaveChangesAsync();
    }
}