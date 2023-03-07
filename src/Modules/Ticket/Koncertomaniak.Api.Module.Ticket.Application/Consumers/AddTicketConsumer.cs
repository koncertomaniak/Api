using Koncertomaniak.Api.Module.Ticket.Core.Entities;
using Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal;
using Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal.Repositories;
using Koncertomaniak.Api.Shared.Infrastructure.QueueMessages;
using MassTransit;

namespace Koncertomaniak.Api.Module.Ticket.Application.Consumers;

public class AddTicketConsumer : IConsumer<AddTicketMessage>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly ITicketProviderRepository _ticketProviderRepository;
    private readonly ITicketUnitOfWork _unitOfWork;
    
    public AddTicketConsumer(ITicketRepository ticketRepository, ITicketProviderRepository ticketProviderRepository, ITicketUnitOfWork unitOfWork)
    {
        _ticketRepository = ticketRepository;
        _ticketProviderRepository = ticketProviderRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Consume(ConsumeContext<AddTicketMessage> context)
    {
        var ticketProviderEntity = await _ticketProviderRepository.GetTicketProviderByName(context.Message.ProviderName);
        var ticketEntity = new EventTicket(context.Message.Url, ticketProviderEntity, context.Message.Event);
        
        await _ticketRepository.CreateEventTicket(ticketEntity);
        await _unitOfWork.CommitChanges();
    }
}