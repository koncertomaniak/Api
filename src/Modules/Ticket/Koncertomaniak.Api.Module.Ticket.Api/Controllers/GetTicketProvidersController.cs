using Koncertomaniak.Api.Module.Ticket.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Koncertomaniak.Api.Module.Ticket.Api.Controllers;

public class GetTicketProvidersController : BaseController
{
    public GetTicketProvidersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetTicketProviders([FromQuery] Guid eventId)
    {
        var result = await Mediator.Send(new GetTicketProvidersModel(eventId));

        return Ok(result);
    }
}