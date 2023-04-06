using Koncertomaniak.Api.Module.Auth.Infrastructure.Dal.Repositories;
using Lamar;

namespace Koncertomaniak.Api.Module.Auth.Infrastructure.Dal;

public class DalRegistry : ServiceRegistry
{
    public DalRegistry()
    {
        Use<AuthDbContext>().Transient();
        
        For<IApiClientRepository>().Use<ApiClientRepository>().Singleton();
    }
}