namespace Koncertomaniak.Api.Module.Event.Infrastructure.Dal.Repositories;

public interface IEventRepository
{
    Task AddEvent(Core.Entities.Event @event);
    Task<Core.Entities.Event?> GetEventByName(string name);
    Task<List<Core.Entities.Event>> GetEvents(int page = 1);
    Task<List<Core.Entities.Event>> SearchEvents(string term, int page);
}