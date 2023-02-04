using Koncertomaniak.Api.Module.Ticket.Core.Models;
using Koncertomaniak.Api.Shared.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Koncertomaniak.Api.Module.Ticket.Api.Controllers;

public class GetEventTicketsController : BaseController
{
    public GetEventTicketsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetEventTickets([FromQuery] Guid eventId)
    {
        var result = await Mediator.Send(new GetEventTicketsModel(eventId));

        var response = new BaseResponseModel(result, null);

        return Ok(response);
    }
}