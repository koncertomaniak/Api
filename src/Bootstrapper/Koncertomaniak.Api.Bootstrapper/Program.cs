using Koncertomaniak.Api.Module.Event.Api;
using Koncertomaniak.Api.Module.Event.Application.Commands.Events.GetEvents;
using Koncertomaniak.Api.Module.Ticket.Api;
using Koncertomaniak.Api.Module.Ticket.Application.Commands.Tickets;
using Koncertomaniak.Api.Module.Ticket.Application.Consumers;
using Koncertomaniak.Api.Shared.Infrastructure;
using Koncertomaniak.Api.Shared.Infrastructure.Mapper;
using Koncertomaniak.Api.Shared.Infrastructure.Middlewares;
using Lamar;
using Lamar.Microsoft.DependencyInjection;
using MassTransit;
using MediatR;

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
registry.AddAutoMapper(typeof(KoncertomaniakMapperProfile));
registry.Scan(x =>
{
    x.TheCallingAssembly();
    x.WithDefaultConventions();
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRequestValidator();
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<AddTicketConsumer>();

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
builder.Services.AddLamar(registry);

builder.Host.UseLamar();

// Modules
builder.Services.AddEventModule();
builder.Services.AddTicketModule();

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

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{
}