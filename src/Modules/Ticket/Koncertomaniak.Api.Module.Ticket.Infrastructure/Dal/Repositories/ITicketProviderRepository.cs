using Koncertomaniak.Api.Module.Ticket.Core.Entities;

namespace Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal.Repositories;

public interface ITicketProviderRepository
{
    Task<TicketProvider> GetTicketProviderByName(string provider);
}