using Domain;

namespace Persistence;
using Microsoft.EntityFrameworkCore;


public class BetEngineDbContext(DbContextOptions options): DbContext(options)
{
    public DbSet<Bets> Bets { get; set; }
}