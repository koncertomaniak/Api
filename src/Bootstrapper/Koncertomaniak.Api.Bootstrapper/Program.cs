using Koncertomaniak.Api.Bootstrapper;
using Koncertomaniak.Api.Shared.Infrastructure.Middlewares;
using Lamar.Microsoft.DependencyInjection;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLamarDefaults();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenDefaults();
builder.Services.AddRequestValidator();
builder.Services.AddApiKeyAuthentication();
builder.Services.AddMassTransitDefaults();

builder.Host.UseLamar();

builder.Services.AddModules();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseModules();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{
}