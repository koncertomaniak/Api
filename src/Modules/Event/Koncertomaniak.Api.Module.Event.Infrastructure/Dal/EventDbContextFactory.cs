using Microsoft.EntityFrameworkCore.Design;

namespace Koncertomaniak.Api.Module.Event.Infrastructure.Dal;

public class EventDbContextFactory : IDesignTimeDbContextFactory<EventDbContext>
{
    public EventDbContext CreateDbContext(string[] args)
    {
        return new EventDbContext();
    }
}