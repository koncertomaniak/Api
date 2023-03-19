using System.Reflection;
using Koncertomaniak.Api.Module.Auth.Core.Entities;
using Koncertomaniak.Api.Shared.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Koncertomaniak.Api.Module.Auth.Infrastructure.Dal;

public class AuthDbContext : DbContext
{
    internal DbSet<ApiClient> ApiClients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Environments.PostgresConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}