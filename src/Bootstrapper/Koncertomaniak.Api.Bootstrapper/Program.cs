using Koncertomaniak.Api.Module.Event.Api;
using Lamar;
using Lamar.Microsoft.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var registry = new ServiceRegistry();

registry.IncludeRegistry<EventRegistry>();
registry.Scan(x =>
{
    x.TheCallingAssembly();
    x.WithDefaultConventions();
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLamar(registry);

builder.Host.UseLamar();

// Modules
builder.Services.AddEventModule();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Modules
app.UseEventModule();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{
}