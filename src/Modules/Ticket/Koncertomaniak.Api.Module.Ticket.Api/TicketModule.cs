using Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal;
using Koncertomaniak.Api.Shared.Infrastructure;
using Koncertomaniak.Api.Shared.Infrastructure.Db;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Koncertomaniak.Api.Module.Ticket.Api;

public static class TicketModule
{
    public static IServiceCollection AddTicketModule(this IServiceCollection services)
    {
        services.InjectDbContext(new TicketDbContext());

        return services;
    }

    public static IApplicationBuilder UseTicketModule(this IApplicationBuilder app)
    {
        if (Environments.AllowAutomaticMigration)
            MigrationRunner.Execute<TicketDbContext>(app);

        return app;
    }
}