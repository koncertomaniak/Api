using Koncertomaniak.Api.Module.Auth.Core.Entities;
using Lamar;
using Microsoft.EntityFrameworkCore;

namespace Koncertomaniak.Api.Module.Auth.Infrastructure.Dal.Repositories;

public class ApiClientRepository : IApiClientRepository
{
    public ApiClientRepository(IContainer container)
    {
        var dbContext = container.GetInstance<AuthDbContext>();
        ApiClients = dbContext.ApiClients;
    }

    private DbSet<ApiClient> ApiClients { get; }

    public async Task<ApiClient?> GetApiClientByApiKey(string secretKey)
    {
        return await ApiClients.Where(x => x.SecretKey == secretKey)
            .FirstOrDefaultAsync();
    }
}