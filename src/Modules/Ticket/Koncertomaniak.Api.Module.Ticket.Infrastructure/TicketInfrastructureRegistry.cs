using Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal;
using Lamar;

namespace Koncertomaniak.Api.Module.Ticket.Infrastructure;

public class TicketInfrastructureRegistry : ServiceRegistry
{
    public TicketInfrastructureRegistry()
    {
        IncludeRegistry<DalRegistry>();
    }
}