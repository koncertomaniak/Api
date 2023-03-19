using Microsoft.EntityFrameworkCore.Design;

namespace Koncertomaniak.Api.Module.Auth.Infrastructure.Dal;

public class AuthDbContextFactory : IDesignTimeDbContextFactory<AuthDbContext>
{
    public AuthDbContext CreateDbContext(string[] args)
    {
        return new AuthDbContext();
    }
}