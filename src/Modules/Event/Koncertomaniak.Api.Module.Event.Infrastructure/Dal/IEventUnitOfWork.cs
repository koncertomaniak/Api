using Koncertomaniak.Api.Module.Event.Infrastructure.Dal.Repositories;
using Koncertomaniak.Api.Shared.Infrastructure.Db;

namespace Koncertomaniak.Api.Module.Event.Infrastructure.Dal;

public interface IEventUnitOfWork : IUnitOfWork
{
    IEventRepository EventRepository { get; }
}