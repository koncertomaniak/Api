using AutoMapper;
using Koncertomaniak.Api.Module.Event.Core.Dtos;
using Koncertomaniak.Api.Module.Event.Core.Models;
using Koncertomaniak.Api.Module.Event.Infrastructure.Dal.Repositories;
using MediatR;

namespace Koncertomaniak.Api.Module.Event.Application.Commands.Events.SearchEvents;

public class SearchEventsRequestHandler : IRequestHandler<SearchEventsModel, EventDisplayInfoDto[]>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;

    public SearchEventsRequestHandler(IEventRepository eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task<EventDisplayInfoDto[]> Handle(SearchEventsModel request, CancellationToken cancellationToken)
    {
        var events = await _eventRepository.SearchEvents(request.Term, request.Page);
        var eventDisplayInfoCollection = _mapper.Map<EventDisplayInfoDto[]>(events);

        return eventDisplayInfoCollection;
    }
}