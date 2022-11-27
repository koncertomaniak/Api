using System.Net;

namespace Koncertomaniak.Api.Shared.Abstractions;

public abstract class KoncertomaniakBaseException : Exception
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.InternalServerError;
    
    protected KoncertomaniakBaseException(string message) : base(message)
    {
    }
}