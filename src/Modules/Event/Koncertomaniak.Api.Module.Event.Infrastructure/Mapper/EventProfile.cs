using AutoMapper;
using Koncertomaniak.Api.Module.Event.Core.Dtos;

namespace Koncertomaniak.Api.Module.Event.Infrastructure.Mapper;

public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<Core.Entities.Event, EventCollectionDto>();
    }
}