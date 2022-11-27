using Koncertomaniak.Api.Shared.Abstractions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Koncertomaniak.Api.Shared.Infrastructure.Middlewares;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (KoncertomaniakBaseException e)
        {
            var response = context.Response;

            response.ContentType = "application/json";
            response.StatusCode = (int)e.StatusCode;

            var responseBody = new BaseResponseModel(null, e.Message, e.StatusCode);

            await response.WriteAsync(JsonConvert.SerializeObject(responseBody));
        }
    }
}