using Koncertomaniak.Api.Module.Ticket.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal.Repositories;

public class TicketRepository : ITicketRepository
{
    public TicketRepository(TicketDbContext context)
    {
        TicketProviders = context.TicketProviders;
    }

    private DbSet<TicketProvider> TicketProviders { get; }

    public async Task<List<TicketProvider>> GetTicketProvidersByEventId(Guid eventId)
    {
        return await TicketProviders.AsNoTracking()
            .Where(e => e.Events.Id == eventId)
            .ToListAsync();
    }
}