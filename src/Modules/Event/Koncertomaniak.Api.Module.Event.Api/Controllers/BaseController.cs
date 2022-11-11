using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Koncertomaniak.Api.Module.Event.Api.Controllers;

[ApiController]
[Route($"{BasePath}/[controller]")]
public abstract class BaseController : ControllerBase
{
    private const string BasePath = "/events";
    protected readonly IMediator Mediator;

    protected BaseController(IMediator mediator)
    {
        Mediator = mediator;
    }
}