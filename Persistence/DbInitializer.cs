using Domain;

namespace Persistence;

public class DbInitializer
{
    public static async Task SeedDatabase(BetEngineDbContext context)
    {
        //return if the db is not empty
        if (context.Bet.Any()) return;
        
        var userId1 = Guid.NewGuid();
        var userId2 = Guid.NewGuid();
        var eventId1 = Guid.NewGuid();
        var eventId2 = Guid.NewGuid();
        var eventId3 = Guid.NewGuid();

        var bets = new List<Bet>
        {
            new()
            {
                Id = Guid.NewGuid(),
                UserId = userId1,
                EventId = eventId1,
                Stake = 50.00m,
                Odds = 1.85m,
                Payout = 92.50m,
                Currency = "AUD",
                BetType = BetType.Single,
                Status = BetStatus.Won,
                CreatedAt = DateTime.UtcNow.AddDays(-10),
                SettledAt = DateTime.UtcNow.AddDays(-9)
            },
            new()
            {
                Id = Guid.NewGuid(),
                UserId = userId1,
                EventId = eventId2,
                Stake = 100.00m,
                Odds = 3.20m,
                Payout = null,
                Currency = "AUD",
                BetType = BetType.Single,
                Status = BetStatus.Pending,
                CreatedAt = DateTime.UtcNow.AddDays(-1),
                SettledAt = null
            },
            new()
            {
                Id = Guid.NewGuid(),
                UserId = userId1,
                EventId = eventId3,
                Stake = 25.00m,
                Odds = 2.50m,
                Payout = null,
                Currency = "AUD",
                BetType = BetType.Multi,
                Status = BetStatus.Lost,
                CreatedAt = DateTime.UtcNow.AddDays(-5),
                SettledAt = DateTime.UtcNow.AddDays(-4)
            },
            new()
            {
                Id = Guid.NewGuid(),
                UserId = userId2,
                EventId = eventId1,
                Stake = 200.00m,
                Odds = 1.50m,
                Payout = 300.00m,
                Currency = "USD",
                BetType = BetType.Single,
                Status = BetStatus.Won,
                CreatedAt = DateTime.UtcNow.AddDays(-7),
                SettledAt = DateTime.UtcNow.AddDays(-6)
            },
            new()
            {
                Id = Guid.NewGuid(),
                UserId = userId2,
                EventId = eventId2,
                Stake = 75.00m,
                Odds = 4.00m,
                Payout = null,
                Currency = "USD",
                BetType = BetType.EachWay,
                Status = BetStatus.Void,
                CreatedAt = DateTime.UtcNow.AddDays(-3),
                SettledAt = DateTime.UtcNow.AddDays(-3)
            },
            new()
            {
                Id = Guid.NewGuid(),
                UserId = userId2,
                EventId = eventId3,
                Stake = 30.00m,
                Odds = 2.10m,
                Payout = null,
                Currency = "USD",
                BetType = BetType.Single,
                Status = BetStatus.Pending,
                CreatedAt = DateTime.UtcNow.AddHours(-6),
                SettledAt = null
            },
        };
        
        context.Bet.AddRange(bets);
        await context.SaveChangesAsync();
    }
}