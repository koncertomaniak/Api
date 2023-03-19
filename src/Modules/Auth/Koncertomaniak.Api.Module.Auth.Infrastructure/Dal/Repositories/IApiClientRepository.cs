using Koncertomaniak.Api.Module.Auth.Core.Entities;

namespace Koncertomaniak.Api.Module.Auth.Infrastructure.Dal.Repositories;

public interface IApiClientRepository
{
    Task<ApiClient?> GetApiClientByApiKey(string secretKey);
}