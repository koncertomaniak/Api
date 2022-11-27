using Koncertomaniak.Api.Module.Event.Core.Models;
using Koncertomaniak.Api.Shared.Abstractions;
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
        var model = new SearchEventsModel(term, page);
        var result = await Mediator.Send(model);

        var response = new BaseResponseModel(result, null);

        return Ok(response);
    }
}