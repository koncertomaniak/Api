using Koncertomaniak.Api.Module.Event.Core.Dtos;
using MediatR;

namespace Koncertomaniak.Api.Module.Event.Core.Models;

public record GetEventsModel(int Page) : IRequest<EventCollectionDto[]>;