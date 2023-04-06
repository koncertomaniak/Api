using Lamar;
using Microsoft.EntityFrameworkCore;

namespace Koncertomaniak.Api.Module.Event.Infrastructure.Dal.Repositories;

public class EventRepository : IEventRepository
{
    private const int PageSize = 20;

    public EventRepository(EventDbContext dbContext)
    {
        Events = dbContext.Events;
    }

    private DbSet<Core.Entities.Event> Events { get; }

    public async Task AddEvent(Core.Entities.Event @event)
    {
        await Events.AddAsync(@event);
    }

    public async Task<Core.Entities.Event?> GetEventByName(string name)
    {
        return await Events.Where(e => e.Name.Contains(name))
            .FirstOrDefaultAsync();
    }

    public async Task<List<Core.Entities.Event>> GetEvents(int page)
    {
        return await Events.AsNoTracking()
            .OrderBy(e => e.HappeningDate)
            .Skip(PageSize * page)
            .Take(PageSize)
            .ToListAsync();
    }

    public async Task<List<Core.Entities.Event>> SearchEvents(string term, int page)
    {
        return await Events.AsNoTracking()
            .Where(e => e.Name.ToLower().Contains(term.ToLower()))
            .Skip(PageSize * page)
            .Take(PageSize)
            .ToListAsync();
    }
}