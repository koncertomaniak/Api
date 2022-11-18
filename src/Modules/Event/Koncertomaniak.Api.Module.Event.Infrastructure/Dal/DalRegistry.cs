using Koncertomaniak.Api.Module.Event.Infrastructure.Dal.Repositories;
using Koncertomaniak.Api.Shared.Infrastructure.Db;
using Lamar;

namespace Koncertomaniak.Api.Module.Event.Infrastructure.Dal;

public class DalRegistry : ServiceRegistry
{
    public DalRegistry()
    {
        Use<EventDbContext>().Singleton();

        For<IUnitOfWork>().Use<EventUnitOfWork>().Transient();
        For<IEventRepository>().Use<EventRepository>().Singleton();
    }
}