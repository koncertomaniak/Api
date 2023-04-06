using Koncertomaniak.Api.Module.Auth.Infrastructure.Dal;
using Koncertomaniak.Api.Shared.Infrastructure;
using Koncertomaniak.Api.Shared.Infrastructure.Db;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Koncertomaniak.Api.Module.Auth.Api;

public static class AuthModule
{
    public static IServiceCollection AddAuthModule(this IServiceCollection services)
    {
        return services;
    }

    public static IApplicationBuilder UseAuthModule(this IApplicationBuilder app)
    {
        if (Environments.AllowAutomaticMigration)
            MigrationRunner.Execute<AuthDbContext>(app);

        return app;
    }
}