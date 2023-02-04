using Koncertomaniak.Api.Module.Ticket.Core.Dtos;
using MediatR;

namespace Koncertomaniak.Api.Module.Ticket.Core.Models;

public record GetEventTicketsModel(Guid EventId) : IRequest<List<TicketProviderDto>>;