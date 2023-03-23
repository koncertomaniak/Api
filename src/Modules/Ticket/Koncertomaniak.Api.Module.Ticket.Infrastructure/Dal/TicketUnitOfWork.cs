﻿using Lamar;

namespace Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal;

public class TicketUnitOfWork : ITicketUnitOfWork
{
    private readonly TicketDbContext _context;

    public TicketUnitOfWork(IContainer container)
    {
        var dbContext = container.GetInstance<TicketDbContext>();
        _context = dbContext;
    }

    public async Task CommitChanges()
    {
        await _context.SaveChangesAsync();
    }
}