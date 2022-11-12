using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Koncertomaniak.Api.Shared.Infrastructure.Db;

public static class MigrationRunner
{
    public static void Execute<T>(IApplicationBuilder app) where T : DbContext
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        using var context = serviceScope.ServiceProvider.GetService<T>();

        context?.Database.Migrate();
    }
}