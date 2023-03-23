using Koncertomaniak.Api.Module.Event.Core.Entities;

namespace Koncertomaniak.Api.Shared.Infrastructure.QueueMessages;

public record AddTicketMessage(Guid EventTicketId, Event Event, string ProviderName, string Url);
// {
//     public Guid EventId { get; init; }
//     public string ProviderName { get; init; }
//     public string Url { get; init; }
// }