using Koncertomaniak.Api.Module.Ticket.Core.Entities;
using Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal;
using Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal.Repositories;
using Koncertomaniak.Api.Shared.Infrastructure.QueueMessages;
using MassTransit;

namespace Koncertomaniak.Api.Module.Ticket.Application.Consumers;

public class AddTicketConsumer : IConsumer<AddTicketMessage>
{
    private readonly ITicketUnitOfWork _unitOfWork;

    public AddTicketConsumer(ITicketUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Consume(ConsumeContext<AddTicketMessage> context)
    {
        var ticketProviderEntity =
            await _unitOfWork.TicketProviderRepository.GetTicketProviderByName(context.Message.ProviderName);
        var ticketEntity = new EventTicket(context.Message.EventTicketId, context.Message.Url, ticketProviderEntity,
            context.Message.Event);

        await _unitOfWork.TicketRepository.CreateEventTicket(ticketEntity);
        await _unitOfWork.CommitChanges();
    }
}