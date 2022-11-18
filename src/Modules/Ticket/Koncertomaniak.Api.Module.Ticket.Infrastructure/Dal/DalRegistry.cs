using Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal.Repositories;
using Koncertomaniak.Api.Shared.Infrastructure.Db;
using Lamar;

namespace Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal;

public class DalRegistry : ServiceRegistry
{
    public DalRegistry()
    {
        Use<TicketDbContext>().Singleton();

        For<IUnitOfWork>().Use<TicketUnitOfWork>().Transient();
        For<ITicketRepository>().Use<TicketRepository>().Singleton();
    }
}