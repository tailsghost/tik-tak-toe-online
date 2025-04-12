using Microsoft.EntityFrameworkCore;
using tik_tak_toe_server.Database.Entities;

namespace tik_tak_toe_server.Database.Context;

public class ApplicationContext : DbContext
{
    public DbSet<Game> Games { get; set; }

    public ApplicationContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DEFAULT_CONNECTION"));
    }
}

