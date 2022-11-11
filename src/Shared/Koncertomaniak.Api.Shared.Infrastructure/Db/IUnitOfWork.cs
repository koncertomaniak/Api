namespace Koncertomaniak.Api.Shared.Infrastructure.Db;

public interface IUnitOfWork
{
    Task CommitChanges();
}