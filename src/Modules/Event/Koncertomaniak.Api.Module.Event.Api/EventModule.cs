using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Koncertomaniak.Api.Module.Event.Api;

public static class EventModule
{
    public static IServiceCollection AddEventModule(this IServiceCollection services)
    {
        return services;
    }

    public static IApplicationBuilder UseEventModule(this IApplicationBuilder app)
    {
        return app;
    }
}