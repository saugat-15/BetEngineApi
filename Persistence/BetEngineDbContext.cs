using Domain;

namespace Persistence;
using Microsoft.EntityFrameworkCore;


public class BetEngineDbContext(DbContextOptions options): DbContext(options)
{
    public DbSet<Bet> Bet { get; set; }
}