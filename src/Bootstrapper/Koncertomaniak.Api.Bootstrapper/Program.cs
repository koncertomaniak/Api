using Koncertomaniak.Api.Module.Event.Api;
using Koncertomaniak.Api.Module.Event.Application.Commands.Events.GetEvents;
using Koncertomaniak.Api.Module.Ticket.Api;
using Koncertomaniak.Api.Module.Ticket.Application.Commands.Tickets;
using Koncertomaniak.Api.Module.Ticket.Application.Consumers;
using Koncertomaniak.Api.Module.Auth.Api;
using Koncertomaniak.Api.Module.Auth.Application.Commands.VerifyApiKey;
using Koncertomaniak.Api.Shared.Infrastructure;
using Koncertomaniak.Api.Shared.Infrastructure.Filters;
using Koncertomaniak.Api.Shared.Infrastructure.Mapper;
using Koncertomaniak.Api.Shared.Infrastructure.Middlewares;
using Koncertomaniak.Api.Shared.Infrastructure.QueueMessages;
using Lamar;
using Lamar.Microsoft.DependencyInjection;
using MassTransit;
using MediatR;
using Environments = Koncertomaniak.Api.Shared.Infrastructure.Environments;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);
var registry = new ServiceRegistry();

var assemblies = new[]
{
    typeof(GetEventsRequestHandler).Assembly,
    typeof(GetEventTicketsRequestHandler).Assembly
};

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

builder.Services.AddControllers();
builder.Services.AddScoped<AdminIpWhitelistFilter>(container => new AdminIpWhitelistFilter());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRequestValidator();
builder.Services.AddMassTransit(x =>
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
builder.Host.UseLamar();

builder.Services.AddLamar(registry);

// Modules
builder.Services.AddEventModule();
builder.Services.AddTicketModule();

if (Environments.AuthModuleEnabled)
    builder.Services.AddAuthModule();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Middlewares
app.UseMiddleware<GlobalExceptionMiddleware>();

// Modules
app.UseEventModule();
app.UseTicketModule();
app.UseAuthModule();

app.UseCertificateForwarding();
app.UseAuthentication();

if (Environments.AuthModuleEnabled)
    app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{
}