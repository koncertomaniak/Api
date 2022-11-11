using Koncertomaniak.Api.Module.Event.Infrastructure.Dal.Repositories;
using Koncertomaniak.Api.Shared.Infrastructure.Db;
using Lamar;
using Microsoft.Extensions.DependencyInjection;

namespace Koncertomaniak.Api.Module.Event.Infrastructure.Dal;

public class DalRegistry : ServiceRegistry
{
    public DalRegistry()
    {
        this.AddSingleton<EventDbContext>();

        For<IUnitOfWork>().Use<EventUnitOfWork>().Transient();
        For<IEventRepository>().Use<EventRepository>().Singleton();
    }
}