using System.ComponentModel.DataAnnotations.Schema;
using Koncertomaniak.Api.Shared.Abstractions;

namespace Koncertomaniak.Api.Module.Auth.Core.Entities;

[Table("ApiClients")]
public class ApiClient : BaseEntity
{
    private ApiClient()
    {
    }

    public ApiClient(string secretKey, string providerName)
    {
        SecretKey = secretKey;
        ProviderName = providerName;
    }

    public string SecretKey { get; set; } = null!;
    public string ProviderName { get; set; } = null!;
}