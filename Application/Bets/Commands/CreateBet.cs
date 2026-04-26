using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Domain;

namespace Application.Bets.Commands;

public class CreateBet
{
    public class Command : IRequest<string>
    {
        public required Domain.Bet Bet { get; set; }
    }

    public class Handler(BetEngineDbContext context) : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            var existingBet =
                    await context.Bet.FirstOrDefaultAsync(b => b.IdempotencyKey == request.Bet.IdempotencyKey,
                        cancellationToken)
                ;
            if (existingBet != null) return existingBet.Id.ToString();
            
            request.Bet.Id = Guid.NewGuid();

            var bet = context.Bet.Add(request.Bet);
            await context.SaveChangesAsync(cancellationToken);
            return request.Bet.Id.ToString();
        }
    }
}