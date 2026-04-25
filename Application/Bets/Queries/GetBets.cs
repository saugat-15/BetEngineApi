using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Bets.Queries;

public class GetBets
{
    public class Query : IRequest<List<Domain.Bets>>
    {
        
    }
    
    public class Handler(BetEngineDbContext context): IRequestHandler<Query, List<Domain.Bets>>
    {
        public async Task<List<Domain.Bets>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await context.Bets.ToListAsync(cancellationToken);
        }
    }
    
}