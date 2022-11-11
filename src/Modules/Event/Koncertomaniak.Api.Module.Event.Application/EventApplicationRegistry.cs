using Lamar;
using Microsoft.Extensions.DependencyInjection;

namespace Koncertomaniak.Api.Module.Event.Application;

public class EventApplicationRegistry : ServiceRegistry
{
    public EventApplicationRegistry()
    {
        this.AddMediator(option => option.ServiceLifetime = ServiceLifetime.Transient);
    }
}