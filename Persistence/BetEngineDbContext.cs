using Domain;

namespace Persistence;
using Microsoft.EntityFrameworkCore;


public class BetEngineDbContext(DbContextOptions options): DbContext(options)
{
    public DbSet<Bets> Bets { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bets>()
            .HasIndex(b => b.IdempotencyKey)
            .IsUnique();
    }
}