using System.Reflection;
using Koncertomaniak.Api.Module.Event.Core.Entities;
using Koncertomaniak.Api.Shared.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Koncertomaniak.Api.Module.Event.Infrastructure.Dal;

public class EventDbContext : DbContext
{
    internal DbSet<Location> Locations { get; init; }
    internal DbSet<Core.Entities.Event> Events { get; init; }

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