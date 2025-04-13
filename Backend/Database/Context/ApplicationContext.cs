using Microsoft.EntityFrameworkCore;
using tik_tak_toe_server.Database.Entities;

namespace tik_tak_toe_server.Database.Context;

public class ApplicationContext : DbContext
{
    public DbSet<Game> Games { get; set; }

    public DbSet<User> Users { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    public ApplicationContext()
    {
        Database.EnsureCreated();
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>()
            .HasMany(m => m.Games)
            .WithMany(m => m.Players);

        builder.Entity<Game>()
            .HasOne(o => o.Winner)
            .WithMany(m => m.WinnerGames)
            .HasForeignKey(g => g.WinnerId);

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DEFAULT_CONNECTION"));
    }
}

