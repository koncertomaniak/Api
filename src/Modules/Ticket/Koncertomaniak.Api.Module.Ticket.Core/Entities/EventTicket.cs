using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Koncertomaniak.Api.Shared.Abstractions;

namespace Koncertomaniak.Api.Module.Ticket.Core.Entities;

[Table("EventTickets")]
public class EventTicket : BaseEntity
{
    [Url] public string Url { get; set; } = null!;

    [ForeignKey("TicketProvidersPK")] public virtual TicketProvider TicketProvider { get; set; } = null!;

    [ForeignKey("EventsPK")] public virtual Event.Core.Entities.Event Events { get; set; } = null!;

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}