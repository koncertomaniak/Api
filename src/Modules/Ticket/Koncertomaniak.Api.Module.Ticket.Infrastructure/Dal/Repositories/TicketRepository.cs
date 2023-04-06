using Koncertomaniak.Api.Module.Ticket.Core.Entities;
using Lamar;
using Microsoft.EntityFrameworkCore;

namespace Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly TicketDbContext _dbContext;

    public TicketRepository(TicketDbContext dbContext)
    {
        _dbContext = dbContext;
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
        foreach (var eventTicket in EventTickets)
        {
            var existing = EventTickets.Local.FirstOrDefault(x => x.Id == entity.Id);
            if (existing != null)
                return;

            _dbContext.Attach(entity.Events);
            await EventTickets.AddAsync(entity);
        }
    }
}