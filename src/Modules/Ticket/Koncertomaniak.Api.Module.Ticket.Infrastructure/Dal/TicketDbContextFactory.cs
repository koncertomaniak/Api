using Microsoft.EntityFrameworkCore.Design;

namespace Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal;

public class TicketDbContextFactory : IDesignTimeDbContextFactory<TicketDbContext>
{
    public TicketDbContext CreateDbContext(string[] args)
    {
        return new TicketDbContext();
    }
}