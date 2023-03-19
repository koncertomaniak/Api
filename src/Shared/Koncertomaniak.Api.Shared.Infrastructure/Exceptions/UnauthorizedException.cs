using System.Net;
using Koncertomaniak.Api.Shared.Abstractions;

namespace Koncertomaniak.Api.Shared.Infrastructure.Exceptions;

public class UnauthorizedException : KoncertomaniakBaseException
{
    public UnauthorizedException(string message) : base(message)
    {
    }

    public HttpStatusCode StatusCode { get; } = HttpStatusCode.Unauthorized;
}