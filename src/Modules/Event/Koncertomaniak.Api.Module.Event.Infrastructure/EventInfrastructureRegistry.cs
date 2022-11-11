using Koncertomaniak.Api.Module.Event.Infrastructure.Dal;
using Lamar;
using Microsoft.Extensions.DependencyInjection;

namespace Koncertomaniak.Api.Module.Event.Infrastructure;

public class EventInfrastructureRegistry : ServiceRegistry
{
    public EventInfrastructureRegistry()
    {
        this.AddAutoMapper(typeof(EventInfrastructureRegistry));

        IncludeRegistry<DalRegistry>();
    }
}