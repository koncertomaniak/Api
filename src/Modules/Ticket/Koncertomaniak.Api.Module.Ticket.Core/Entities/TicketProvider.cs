using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Koncertomaniak.Api.Shared.Abstractions;

namespace Koncertomaniak.Api.Module.Ticket.Core.Entities;

[Table("TicketProviders")]
public class TicketProvider : BaseEntity
{
    [MaxLength(50)] public string ServiceName { get; set; } = null!;

    [Url] public string ImageUrl { get; set; } = null!;

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}