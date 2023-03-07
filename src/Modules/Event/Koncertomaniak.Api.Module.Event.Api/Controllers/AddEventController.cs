using System.Net;
using Koncertomaniak.Api.Module.Event.Core.Models;
using Koncertomaniak.Api.Module.Event.Infrastructure.Dal;
using Koncertomaniak.Api.Shared.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Koncertomaniak.Api.Module.Event.Api.Controllers;

public class AddEventController : BaseController
{
    private readonly IEventUnitOfWork _unitOfWork;
    
    public AddEventController(IMediator mediator, IEventUnitOfWork unitOfWork) : base(mediator)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task<IActionResult> AddEvent([FromBody] AddEventModel eventModel)
    {
        await Mediator.Send(eventModel);
        await _unitOfWork.CommitChanges();
        
        return Ok(new BaseResponseModel(null, null, HttpStatusCode.Created));
    }
}