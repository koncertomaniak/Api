using Koncertomaniak.Api.Module.Event.Core.Models;
using Koncertomaniak.Api.Module.Event.Infrastructure.Dal;
using Koncertomaniak.Api.Module.Event.Infrastructure.Dal.Repositories;
using Koncertomaniak.Api.Shared.Infrastructure.QueueMessages;
using MassTransit;
using MediatR;

namespace Koncertomaniak.Api.Module.Event.Application.Commands.Events.AddEvent;

public class AddEventRequestHandler : IRequestHandler<AddEventModel>
{
    private readonly IEventUnitOfWork _unitOfWork;
    private readonly IPublishEndpoint _publishEndpoint;

    public AddEventRequestHandler(IEventUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint)
    {
        _unitOfWork = unitOfWork;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<Unit> Handle(AddEventModel request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.EventRepository.GetEventByName(request.Name.TrimEnd().TrimStart());
        if (entity == null)
        {
            entity =
                new Core.Entities.Event(request.Name, request.ImageUrl, request.Description, request.HappeningDate);
            await _unitOfWork.EventRepository.AddEvent(entity);
        }

        await _publishEndpoint.Publish(
            new AddTicketMessage(Guid.NewGuid(), entity, request.TickerProvider, request.TicketUrl),
            cancellationToken);

        return Unit.Value;
    }
}