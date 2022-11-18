using Koncertomaniak.Api.Module.Ticket.Infrastructure;
using Lamar;

namespace Koncertomaniak.Api.Module.Ticket.Api;

public class TicketRegistry : ServiceRegistry
{
    public TicketRegistry()
    {
        IncludeRegistry<TicketInfrastructureRegistry>();
    }
}