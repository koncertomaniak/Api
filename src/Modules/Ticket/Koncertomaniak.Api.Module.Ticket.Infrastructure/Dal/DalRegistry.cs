using Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal.Repositories;
using Lamar;

namespace Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal;

public class DalRegistry : ServiceRegistry
{
    public DalRegistry()
    {
        //Use<TicketDbContext>().Singleton();

        For<ITicketUnitOfWork>().Use<TicketUnitOfWork>().Transient();
        For<ITicketRepository>().Use<TicketRepository>().Singleton();
        For<ITicketProviderRepository>().Use<TicketProviderRepository>().Singleton();
    }
}