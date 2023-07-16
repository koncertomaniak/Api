using Koncertomaniak.Api.Module.Event.Core.Entities;
using Koncertomaniak.Api.Module.Event.Core.Models;
using Koncertomaniak.Api.Module.Event.Infrastructure.Dal;
using Koncertomaniak.Api.Shared.Infrastructure.QueueMessages;
using MassTransit;
using MediatR;

namespace Koncertomaniak.Api.Module.Event.Application.Commands.Events.AddEvent;

public class AddEventRequestHandler : IRequestHandler<AddEventModel>
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IEventUnitOfWork _unitOfWork;

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
            var locations = request.Locations.Select(l => new Location(l.City, l.Place)).ToList();
            entity =
                new Core.Entities.Event(request.Name, request.ImageUrl, request.Description, request.HappeningDate,
                    locations);
            entity.HappeningLocation = locations;
            await _unitOfWork.EventRepository.AddEvent(entity);
        }

        foreach (var location in entity.HappeningLocation)
            if (!CheckCityAndPlaceIsExisting(entity, location.City!, location.Place!))
            {
                entity.HappeningLocation.Add(new Location(location.City, location.Place));
                await _unitOfWork.EventRepository.UpdateEvent(entity);
            }

        await _unitOfWork.CommitChanges();

        await _publishEndpoint.Publish(
            new AddTicketMessage(Guid.NewGuid(), entity, request.TickerProvider, request.TicketUrl),
            cancellationToken);

        return Unit.Value;
    }

    private static bool CheckCityAndPlaceIsExisting(Core.Entities.Event entity, string city, string place)
    {
        return entity.HappeningLocation.Exists(l => l.City == city && l.Place == place);
    }
}