using Koncertomaniak.Api.Module.Ticket.Core.Entities;

namespace Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal.Repositories;

public interface ITicketRepository
{
    Task<List<TicketProvider>> GetTicketProvidersByEventId(Guid eventId);
}