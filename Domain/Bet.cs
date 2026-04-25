namespace Domain;

public enum BetType
{
    Single,
    Multi,
    EachWay
}

public enum BetStatus
{
    Pending,
    Won,
    Lost,
    Void,
    Cancelled
}

public class Bet
{
    //identity fields
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }

        public decimal Stake { get; set; }
        public decimal Odds { get; set; }
        public decimal? Payout { get; set; }
        public required string Currency { get; set; }

        public BetType BetType { get; set; }
        public BetStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? SettledAt { get; set; }
}