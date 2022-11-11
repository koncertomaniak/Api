using Koncertomaniak.Api.Module.Event.Core.Models;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Koncertomaniak.Api.Module.Event.Api.Controllers;

public class GetEventsController : BaseController
{
    public GetEventsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetEvents([FromQuery] int page = 0)
    {
        var model = new GetEventsModel
        {
            Page = page
        };

        var result = await Mediator.Send(model);

        return Ok(result);
    }
}