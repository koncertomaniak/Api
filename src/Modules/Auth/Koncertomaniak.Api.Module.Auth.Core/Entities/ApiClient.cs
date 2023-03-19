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
        CreatedAt = DateTimeOffset.Now;
        UpdatedAt = DateTimeOffset.Now;
    }

    public string SecretKey { get; set; } = null!;
    public string ProviderName { get; set; } = null!;
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}