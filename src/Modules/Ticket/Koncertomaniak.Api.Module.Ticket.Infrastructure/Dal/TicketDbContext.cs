using System.Reflection;
using Koncertomaniak.Api.Module.Ticket.Core.Entities;
using Koncertomaniak.Api.Shared.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal;

public class TicketDbContext : DbContext
{
    internal DbSet<EventTicket> EventTickets { get; init; }
    internal DbSet<TicketProvider> TicketProviders { get; init; }

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