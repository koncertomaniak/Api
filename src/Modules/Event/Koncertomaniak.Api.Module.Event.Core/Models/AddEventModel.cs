using MediatR;

namespace Koncertomaniak.Api.Module.Event.Core.Models;

public record AddEventModel(string Name, string ImageUrl, string Description, DateTimeOffset HappeningDate, string TickerProvider, string TicketUrl) : IRequest;