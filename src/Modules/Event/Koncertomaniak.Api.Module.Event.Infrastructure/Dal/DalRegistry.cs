using Koncertomaniak.Api.Module.Event.Infrastructure.Dal.Repositories;
using Lamar;

namespace Koncertomaniak.Api.Module.Event.Infrastructure.Dal;

public class DalRegistry : ServiceRegistry
{
    public DalRegistry()
    {
        //Use<EventDbContext>().Singleton();
        //Injectable<EventDbContext>();

        For<IEventUnitOfWork>().Use<EventUnitOfWork>().Singleton();
        For<IEventRepository>().Use<EventRepository>().Singleton();
    }
}