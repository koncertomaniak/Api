using FluentValidation;
using FluentValidation.AspNetCore;
using Koncertomaniak.Api.Module.Event.Core.Models;
using Koncertomaniak.Api.Module.Event.Core.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Koncertomaniak.Api.Shared.Infrastructure;

public static class StartupExtensions
{
    public static void AddRequestValidator(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation()
            .AddScoped<IValidator<AddEventModel>, AddEventValidator>();
    }
}