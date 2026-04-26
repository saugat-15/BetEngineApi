using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Bets.Queries;

public class GetBets
{
    public class Query : IRequest<List<Bet>>
    {
        
    }
    
    public class Handler(BetEngineDbContext context): IRequestHandler<Query, List<Bet>>
    {
        public async Task<List<Bet>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await context.Bet.ToListAsync(cancellationToken);
        }
    }
    
}