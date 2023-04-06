using Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal.Repositories;
using Lamar;

namespace Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal;

public class DalRegistry : ServiceRegistry
{
    public DalRegistry()
    {
        Use<TicketDbContext>().Transient();
        
        For<ITicketUnitOfWork>().Use<TicketUnitOfWork>().Transient();
        For<ITicketRepository>().Use<TicketRepository>().Transient();
        For<ITicketProviderRepository>().Use<TicketProviderRepository>().Transient();
    }
}