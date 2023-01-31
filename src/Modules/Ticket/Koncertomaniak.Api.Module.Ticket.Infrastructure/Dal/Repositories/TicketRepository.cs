using Koncertomaniak.Api.Module.Ticket.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal.Repositories;

public class TicketRepository : ITicketRepository
{
    public TicketRepository(TicketDbContext context)
    {
        EventTickets = context.EventTickets;
    }

    private DbSet<EventTicket> EventTickets { get; }

    public async Task<List<EventTicket>> GetEventTicketsByEventId(Guid eventId)
    {
        return await EventTickets.AsNoTracking()
            .Where(e => e.Events.Id == eventId)
            .Include(e => e.TicketProvider)
            .ToListAsync();
    }
}