using Koncertomaniak.Api.Shared.Infrastructure.Exceptions;
using Koncertomaniak.Api.Shared.Infrastructure.QueueMessages;
using Koncertomaniak.Api.Shared.Infrastructure.QueueReponses;
using MassTransit;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Koncertomaniak.Api.Shared.Infrastructure.Filters;

public class ApiKeyAuthorizationFilter : IAsyncActionFilter
{
    private readonly IRequestClient<VerifyApiKeyMessage> _publishEndpoint;

    public ApiKeyAuthorizationFilter(IRequestClient<VerifyApiKeyMessage> publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var apiKey = context.HttpContext.Request.Headers["X-API-KEY"];

        var response =
            await _publishEndpoint.GetResponse<VerifyApiKeyResponse>(new VerifyApiKeyMessage(apiKey.ToString()));
        if (response.Message.Id == Guid.Empty)
        {
            context.HttpContext.Response.StatusCode = 401;
            throw new UnauthorizedException("Invalid API key");
        }

        await next();
    }
}