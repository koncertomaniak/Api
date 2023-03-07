using Koncertomaniak.Api.Module.Ticket.Core.Entities;
using Lamar;
using Microsoft.EntityFrameworkCore;

namespace Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly TicketDbContext _dbContext;

    public TicketRepository(IContainer container)
    {
        _dbContext = container.GetInstance<TicketDbContext>();
        EventTickets = _dbContext.EventTickets;
    }

    private DbSet<EventTicket> EventTickets { get; }

    public async Task<List<EventTicket>> GetEventTicketsByEventId(Guid eventId)
    {
        return await EventTickets.AsNoTracking()
            .Where(e => e.Events.Id == eventId)
            .Include(e => e.TicketProvider)
            .ToListAsync();
    }

    public async Task CreateEventTicket(EventTicket entity)
    {
        //_dbContext.Entry(entity).State = EntityState.Unchanged;
        _dbContext.Attach(entity.Events);
        await EventTickets.AddAsync(entity);
    }
}