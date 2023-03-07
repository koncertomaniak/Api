namespace Koncertomaniak.Api.Shared.Infrastructure;

public static class Environments
{
    public static string PostgresConnectionString =>
        Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING") ?? string.Empty;

    public static bool AllowAutomaticMigration =>
        bool.Parse(Environment.GetEnvironmentVariable("ALLOW_AUTOMATIC_MIGRATION") ?? "false");

    public static string RabbitMqHost =>
        Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? string.Empty;
    
    public static string RabbitMqUsername =>
        Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? string.Empty;
    
    public static string RabbitMqPassword =>
        Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? string.Empty;
}