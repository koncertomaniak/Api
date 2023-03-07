﻿using Koncertomaniak.Api.Module.Ticket.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal.Repositories;

public class TicketProviderRepository : ITicketProviderRepository
{
    private DbSet<TicketProvider> TicketProviders { get; }
    
    public TicketProviderRepository(TicketDbContext dbContext)
    {
        TicketProviders = dbContext.TicketProviders;
    }

    public async Task<TicketProvider> GetTicketProviderByName(string provider)
    {
        return await TicketProviders.Where(x => x.ServiceName == provider)
            .FirstAsync();
    }
}