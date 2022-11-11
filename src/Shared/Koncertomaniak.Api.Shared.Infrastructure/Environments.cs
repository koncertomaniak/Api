namespace Koncertomaniak.Api.Shared.Infrastructure;

public static class Environments
{
    public static string PostgresConnectionString =>
        Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING") ?? string.Empty;
}