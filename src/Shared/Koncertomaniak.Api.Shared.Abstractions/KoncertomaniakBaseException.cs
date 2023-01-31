using System.Net;

namespace Koncertomaniak.Api.Shared.Abstractions;

public abstract class KoncertomaniakBaseException : Exception
{
    protected KoncertomaniakBaseException(string message) : base(message)
    {
    }

    public HttpStatusCode StatusCode { get; } = HttpStatusCode.InternalServerError;
}