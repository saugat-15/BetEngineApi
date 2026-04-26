using MediatR;
using Persistence;

namespace Application.Bets.Queries;
using Domain;

public class GetBetDetails
{
    public class Query : IRequest<Bet>
    { 
        public Guid Id { get; set; }
    }

    public class Handler(BetEngineDbContext context) : IRequestHandler<Query, Bet>
    {
        public async Task<Bet> Handle(Query request, CancellationToken cancellationToken)
        {
            var bet = await context.Bet.FindAsync([request.Id], cancellationToken);
            return bet ?? throw new Exception($"Bet with ID {request.Id} not found");
        }
    }
}