using Koncertomaniak.Api.Shared.Infrastructure.Db;

namespace Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal;

public class TicketUnitOfWork : IUnitOfWork
{
    private readonly TicketDbContext _context;

    public TicketUnitOfWork(TicketDbContext context)
    {
        _context = context;
    }

    public async Task CommitChanges()
    {
        await _context.SaveChangesAsync();
    }
}