using Koncertomaniak.Api.Module.Ticket.Core.Entities;
using Lamar;
using Microsoft.EntityFrameworkCore;

namespace Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal.Repositories;

public class TicketProviderRepository : ITicketProviderRepository
{
    public TicketProviderRepository(IContainer container)
    {
        var dbContext = container.GetInstance<TicketDbContext>();
        TicketProviders = dbContext.TicketProviders;
    }

    private DbSet<TicketProvider> TicketProviders { get; }

    public async Task<TicketProvider> GetTicketProviderByName(string provider)
    {
        return await TicketProviders.Where(x => x.ServiceName == provider)
            .FirstAsync();
    }
}