using System.Security.Claims;
using System.Text.Encodings.Web;
using Koncertomaniak.Api.Shared.Infrastructure.QueueMessages;
using Koncertomaniak.Api.Shared.Infrastructure.QueueReponses;
using MassTransit;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Koncertomaniak.Api.Shared.Infrastructure.Authentication.Api;

public class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiKeyAuthenticationOptions>
{
    private readonly IRequestClient<VerifyApiKeyMessage> _requestClient;

    public ApiKeyAuthenticationHandler(IOptionsMonitor<ApiKeyAuthenticationOptions> options, ILoggerFactory logger,
        UrlEncoder encoder, ISystemClock clock, IRequestClient<VerifyApiKeyMessage> requestClient) : base(options,
        logger, encoder, clock)
    {
        _requestClient = requestClient;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var apiKey = Request.Headers["X-API-KEY"];

        var response =
            await _requestClient.GetResponse<VerifyApiKeyResponse>(new VerifyApiKeyMessage(apiKey.ToString()));

        if (response.Message.Id == Guid.Empty) return AuthenticateResult.Fail("API Key is not valid");

        var claims = new Claim[]
        {
            new(ClaimTypes.Actor, response.Message.Name),
            new(ClaimTypes.Role, "api")
        };

        var claimsIdentity = new ClaimsIdentity(claims, nameof(ApiKeyAuthenticationHandler));
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        var authenticationTicket = new AuthenticationTicket(claimsPrincipal, Scheme.Name);

        return AuthenticateResult.Success(authenticationTicket);
    }
}