using Lamar;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Koncertomaniak.Api.Shared.Infrastructure.Db;

public static class RegisterDbContextToDi
{
    public static void InjectDbContext<T>(this IServiceCollection services, T dbContext) where T : DbContext
    {
        services.AddSingleton(dbContext);
        // var container = app.ApplicationServices.GetService<IContainer>();
        // var nestedContainer = container?.GetNestedContainer();
        //
        // nestedContainer?.Inject(dbContext);
    }
}