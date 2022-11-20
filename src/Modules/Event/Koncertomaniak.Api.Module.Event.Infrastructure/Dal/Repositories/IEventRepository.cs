namespace Koncertomaniak.Api.Module.Event.Infrastructure.Dal.Repositories;

public interface IEventRepository
{
    Task<List<Core.Entities.Event>> GetEvents(int page = 1);
    Task<List<Core.Entities.Event>> SearchEvents(string term, int page);
}