using Koncertomaniak.Api.Module.Event.Core.Dtos;
using MediatR;

namespace Koncertomaniak.Api.Module.Event.Core.Models;

public record SearchEventsModel(string Term, int Page) : IRequest<EventDisplayInfoDto[]>;