using MediatR;
using Persistence;

namespace Application.Bets.Queries;
using Domain;

public class GetBetDetails
{
    public class Query : IRequest<Bets>
    { 
        public Guid Id { get; set; }
    }

    public class Handler(BetEngineDbContext context) : IRequestHandler<Query, Bets>
    {
        public async Task<Bets> Handle(Query request, CancellationToken cancellationToken)
        {
            var bet = await context.Bets.FindAsync([request.Id], cancellationToken);
            return bet ?? throw new Exception($"Bet with ID {request.Id} not found");
        }
    }
}