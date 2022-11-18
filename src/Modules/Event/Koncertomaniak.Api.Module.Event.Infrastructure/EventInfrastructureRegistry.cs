using Koncertomaniak.Api.Module.Event.Infrastructure.Dal;
using Lamar;

namespace Koncertomaniak.Api.Module.Event.Infrastructure;

public class EventInfrastructureRegistry : ServiceRegistry
{
    public EventInfrastructureRegistry()
    {
        IncludeRegistry<DalRegistry>();
    }
}