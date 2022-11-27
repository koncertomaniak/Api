using Koncertomaniak.Api.Module.Event.Core.Models;
using Koncertomaniak.Api.Shared.Abstractions;
using MediatR;
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
        var model = new GetEventsModel(page);
        var result = await Mediator.Send(model);

        var response = new BaseResponseModel(result, null);

        return Ok(response);
    }
}