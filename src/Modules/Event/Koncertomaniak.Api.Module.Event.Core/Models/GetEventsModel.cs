using Koncertomaniak.Api.Module.Event.Core.Dtos;
using Mediator;

namespace Koncertomaniak.Api.Module.Event.Core.Models;

public record GetEventsModel : IRequest<EventCollectionDto[]>
{
    public int Page { get; set; }
}