using Koncertomaniak.Api.Module.Auth.Infrastructure.Dal;
using Lamar;

namespace Koncertomaniak.Api.Module.Auth.Infrastructure;

public class AuthInfrastructureRegistry : ServiceRegistry
{
    public AuthInfrastructureRegistry()
    {
        IncludeRegistry<DalRegistry>();
    }
}