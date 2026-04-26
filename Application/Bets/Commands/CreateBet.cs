using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Domain;

namespace Application.Bets.Commands;

public class CreateBet
{
    public class Command : IRequest<string>
    {
        public required Domain.Bets Bets { get; set; }
    }

    public class Handler(BetEngineDbContext context) : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            var existingBet =
                    await context.Bets.FirstOrDefaultAsync(b => b.IdempotencyKey == request.Bets.IdempotencyKey,
                        cancellationToken)
                ;
            if (existingBet != null) return existingBet.Id.ToString();
            
            request.Bets.Id = Guid.NewGuid();

            var bet = context.Bets.Add(request.Bets);
            await context.SaveChangesAsync(cancellationToken);
            return request.Bets.Id.ToString();
        }
    }
}