using Koncertomaniak.Api.Module.Event.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Koncertomaniak.Api.Module.Event.Api.Controllers;

public class SearchEventsController : BaseController
{
    public SearchEventsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> SearchEvents([FromQuery] string term, [FromQuery] int page = 0)
    {
        var result = await Mediator.Send(new SearchEventsModel(term, page));

        return Ok(result);
    }
}