using FluentValidation;
using FluentValidation.AspNetCore;
using Koncertomaniak.Api.Module.Auth.Api;
using Koncertomaniak.Api.Module.Auth.Application.Commands.VerifyApiKey;
using Koncertomaniak.Api.Module.Event.Api;
using Koncertomaniak.Api.Module.Event.Application.Commands.Events.GetEvents;
using Koncertomaniak.Api.Module.Event.Core.Models;
using Koncertomaniak.Api.Module.Event.Core.Validators;
using Koncertomaniak.Api.Module.Ticket.Api;
using Koncertomaniak.Api.Module.Ticket.Application.Commands.Tickets;
using Koncertomaniak.Api.Module.Ticket.Application.Consumers;
using Koncertomaniak.Api.Shared.Infrastructure.Filters;
using Koncertomaniak.Api.Shared.Infrastructure.Mapper;
using Koncertomaniak.Api.Shared.Infrastructure.QueueMessages;
using Lamar;
using Lamar.Microsoft.DependencyInjection;
using MassTransit;
using MediatR;
using Environments = Koncertomaniak.Api.Shared.Infrastructure.Environments;

namespace Koncertomaniak.Api.Bootstrapper;

public static class StartupExtensions
{
    public static void AddRequestValidator(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation()
            .AddScoped<IValidator<AddEventModel>, AddEventValidator>();
    }
    
    public static void AddLamarDefaults(this IServiceCollection services)
    {
        var registry = new ServiceRegistry();

        var assemblies = new[]
        {
            typeof(GetEventsRequestHandler).Assembly,
            typeof(GetEventTicketsRequestHandler).Assembly
        };
        
        registry.AddScoped<AdminIpWhitelistFilter>(_ => new AdminIpWhitelistFilter());
        registry.AddMediatR(assemblies);
        registry.IncludeRegistry<EventRegistry>();
        registry.IncludeRegistry<TicketRegistry>();
        registry.IncludeRegistry<AuthRegistry>();
        registry.AddAutoMapper(typeof(KoncertomaniakMapperProfile));
        registry.Scan(x =>
        {
            x.TheCallingAssembly();
            x.WithDefaultConventions();
        });

        services.AddLamar(registry);
    }

    public static void AddMassTransitDefaults(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<AddTicketConsumer>();
            x.AddConsumer<VerifyApiKeyConsumer>()
                .Endpoint(e => e.Name = "verify-api-key");

            x.AddRequestClient<VerifyApiKeyMessage>(new Uri("exchange:verify-api-key"));

            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(Environments.RabbitMqHost, "/", h =>
                {
                    h.Username(Environments.RabbitMqUsername);
                    h.Password(Environments.RabbitMqPassword);
                });
                cfg.ConfigureEndpoints(ctx);
            });
        });
    }

    public static void AddModules(this IServiceCollection services)
    {
        services.AddEventModule();
        services.AddTicketModule();

        if (Environments.AuthModuleEnabled)
            services.AddAuthModule();
    }

    public static void UseModules(this IApplicationBuilder app)
    {
        app.UseEventModule();
        app.UseTicketModule();
        
        if (Environments.AuthModuleEnabled)
            app.UseAuthModule();
    }
}