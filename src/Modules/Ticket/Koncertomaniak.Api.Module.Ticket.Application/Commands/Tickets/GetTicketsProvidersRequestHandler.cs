﻿using AutoMapper;
using Koncertomaniak.Api.Module.Ticket.Core.Dtos;
using Koncertomaniak.Api.Module.Ticket.Core.Models;
using Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal.Repositories;
using MediatR;

namespace Koncertomaniak.Api.Module.Ticket.Application.Commands.Tickets;

public class GetTicketsProvidersRequestHandler : IRequestHandler<GetTicketProvidersModel, List<TicketProviderDto>>
{
    private readonly IMapper _mapper;
    private readonly ITicketRepository _ticketRepository;

    public GetTicketsProvidersRequestHandler(ITicketRepository ticketRepository, IMapper mapper)
    {
        _ticketRepository = ticketRepository;
        _mapper = mapper;
    }

    public async Task<List<TicketProviderDto>> Handle(GetTicketProvidersModel request,
        CancellationToken cancellationToken)
    {
        var providers = await _ticketRepository.GetTicketProvidersByEventId(request.EventId);
        var providersDtos = _mapper.Map<List<TicketProviderDto>>(providers);

        return providersDtos;
    }
}