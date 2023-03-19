using Koncertomaniak.Api.Module.Auth.Infrastructure;
using Lamar;

namespace Koncertomaniak.Api.Module.Auth.Api;

public class AuthRegistry : ServiceRegistry
{
    public AuthRegistry()
    {
        // this.AddScoped<AdminIpWhitelistFilter>(container => new AdminIpWhitelistFilter());
        IncludeRegistry<AuthInfrastructureRegistry>();
    }
}