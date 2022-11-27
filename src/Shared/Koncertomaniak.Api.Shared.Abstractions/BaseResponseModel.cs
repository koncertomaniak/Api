using System.Net;

namespace Koncertomaniak.Api.Shared.Abstractions;

public record BaseResponseModel
(
    object Data,
    string? ErrorMessage,
    HttpStatusCode StatusCode = HttpStatusCode.OK);