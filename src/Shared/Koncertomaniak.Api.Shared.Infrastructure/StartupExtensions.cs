using FluentValidation;
using FluentValidation.AspNetCore;
using Koncertomaniak.Api.Module.Event.Core.Models;
using Koncertomaniak.Api.Module.Event.Core.Validators;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Koncertomaniak.Api.Shared.Infrastructure;

public static class StartupExtensions
{
    public static void AddMessageBroker(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host("localhost", "/", h =>
                {
                    h.Username("root");
                    h.Password("123");
                });
                cfg.ConfigureEndpoints(ctx);
            });
        });
    }

    public static void AddRequestValidator(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation().AddScoped<IValidator<AddEventModel>, AddEventValidator>();
    }
}