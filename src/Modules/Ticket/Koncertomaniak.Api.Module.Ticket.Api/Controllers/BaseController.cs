using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Koncertomaniak.Api.Module.Ticket.Api.Controllers;

[ApiController]
[Route($"{BasePath}/[controller]")]
public abstract class BaseController : ControllerBase
{
    private const string BasePath = "/tickets";

    protected readonly IMediator Mediator;

    protected BaseController(IMediator mediator)
    {
        Mediator = mediator;
    }
}