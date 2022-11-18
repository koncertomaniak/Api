using Koncertomaniak.Api.Module.Event.Infrastructure;
using Lamar;

namespace Koncertomaniak.Api.Module.Event.Api;

public class EventRegistry : ServiceRegistry
{
    public EventRegistry()
    {
        IncludeRegistry<EventInfrastructureRegistry>();
    }
}