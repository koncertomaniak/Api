using Koncertomaniak.Api.Module.Ticket.Core.Dtos;
using MediatR;

namespace Koncertomaniak.Api.Module.Ticket.Core.Models;

public record GetTicketProvidersModel(Guid EventId) : IRequest<List<TicketProviderDto>>;