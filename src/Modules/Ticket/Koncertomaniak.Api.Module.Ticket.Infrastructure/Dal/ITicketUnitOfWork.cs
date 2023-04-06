using Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal.Repositories;
using Koncertomaniak.Api.Shared.Infrastructure.Db;

namespace Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal;

public interface ITicketUnitOfWork : IUnitOfWork
{
    ITicketRepository TicketRepository { get; }
    ITicketProviderRepository TicketProviderRepository { get; }
}