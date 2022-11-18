using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Koncertomaniak.Api.Shared.Abstractions;

namespace Koncertomaniak.Api.Module.Ticket.Core.Entities;

[Table("TicketProviders")]
public class TicketProvider : BaseEntity
{
    [MaxLength(50)] public string ServiceName { get; set; } = null!;

    [Url] public string ImageUrl { get; set; } = null!;

    [Url] public string Url { get; set; } = null!;

    [ForeignKey("EventsPK")] public virtual Event.Core.Entities.Event Events { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}