using AutoMapper;
using Koncertomaniak.Api.Module.Event.Core.Dtos;
using Koncertomaniak.Api.Module.Event.Core.Entities;
using Koncertomaniak.Api.Module.Ticket.Core.Dtos;
using Koncertomaniak.Api.Module.Ticket.Core.Entities;

namespace Koncertomaniak.Api.Shared.Infrastructure.Mapper;

public class KoncertomaniakMapperProfile : Profile
{
    public KoncertomaniakMapperProfile()
    {
        CreateMap<Event, EventDisplayInfoDto>();
        CreateMap<EventTicket, TicketProviderDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TicketProvider.ServiceName))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.TicketProvider.ImageUrl));
    }
}