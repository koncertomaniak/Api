using AutoMapper;
using Koncertomaniak.Api.Module.Event.Core.Dtos;
using Koncertomaniak.Api.Module.Event.Core.Models;
using Koncertomaniak.Api.Module.Event.Infrastructure.Dal.Repositories;
using MediatR;

namespace Koncertomaniak.Api.Module.Event.Application.Commands.Events.GetEvents;

public class GetEventsRequestHandler : IRequestHandler<GetEventsModel, EventDisplayInfoDto[]>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;

    public GetEventsRequestHandler(IEventRepository eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task<EventDisplayInfoDto[]> Handle(GetEventsModel request, CancellationToken cancellationToken)
    {
        var events = await _eventRepository.GetEvents(request.Page);
        var eventDisplayInfoCollection = _mapper.Map<List<Core.Entities.Event>, EventDisplayInfoDto[]>(events);

        return eventDisplayInfoCollection;
    }
}