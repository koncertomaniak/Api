using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Koncertomaniak.Api.Shared.Abstractions;

namespace Koncertomaniak.Api.Module.Ticket.Core.Entities;

[Table("EventTickets")]
public class EventTicket : BaseEntity
{
    private EventTicket()
    {
    }

    public EventTicket(Guid id, string url, TicketProvider ticketProvider, Event.Core.Entities.Event @event)
    {
        Id = id;
        Url = url;
        Events = @event;
        TicketProvider = ticketProvider;
    }

    [Url] public string Url { get; set; } = null!;

    [ForeignKey("TicketProvidersPK")] public TicketProvider TicketProvider { get; set; } = null!;

    [ForeignKey("EventsPK")] public Event.Core.Entities.Event Events { get; set; } = null!;
}