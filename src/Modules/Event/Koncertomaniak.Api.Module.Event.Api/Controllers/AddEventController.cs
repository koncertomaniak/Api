using System.Net;
using Koncertomaniak.Api.Module.Event.Core.Models;
using Koncertomaniak.Api.Shared.Abstractions;
using Koncertomaniak.Api.Shared.Infrastructure.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Koncertomaniak.Api.Module.Event.Api.Controllers;

[Authorize]
public class AddEventController : BaseController
{
    public AddEventController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [ServiceFilter(typeof(AdminIpWhitelistFilter))]
    public async Task<IActionResult> AddEvent([FromBody] AddEventModel eventModel)
    {
        await Mediator.Send(eventModel);

        return Ok(new BaseResponseModel(null, null, HttpStatusCode.Created));
    }
}