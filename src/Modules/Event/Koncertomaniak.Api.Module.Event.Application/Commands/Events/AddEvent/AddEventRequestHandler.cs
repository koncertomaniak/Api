using Koncertomaniak.Api.Module.Event.Core.Models;
using Koncertomaniak.Api.Module.Event.Infrastructure.Dal.Repositories;
using Koncertomaniak.Api.Shared.Infrastructure.QueueMessages;
using MassTransit;
using MediatR;

namespace Koncertomaniak.Api.Module.Event.Application.Commands.Events.AddEvent;

public class AddEventRequestHandler : IRequestHandler<AddEventModel>
{
    private readonly IEventRepository _eventRepository;
    private readonly IPublishEndpoint _publishEndpoint;
    
    public AddEventRequestHandler(IEventRepository eventRepository, IPublishEndpoint publishEndpoint)
    {
        _eventRepository = eventRepository;
        _publishEndpoint = publishEndpoint;
    }
    
    public async Task<Unit> Handle(AddEventModel request, CancellationToken cancellationToken)
    {
        var eventEntity =
            new Core.Entities.Event(request.Name, request.ImageUrl, request.Description, request.HappeningDate);
        await _eventRepository.AddEvent(eventEntity);

        await _publishEndpoint.Publish(new AddTicketMessage(eventEntity, request.TickerProvider, request.TicketUrl), cancellationToken: cancellationToken);

        return Unit.Value;
    }
}