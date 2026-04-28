using MediatR;
using Persistence;

namespace Application.Bets.Commands;

public class DeleteBet
{
    public class Command : IRequest
    {
        public Guid Id { get; set; }
    }

    public class Handler(BetEngineDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var bet = await context.Bet.FindAsync([request.Id], cancellationToken);
            context.Bet.Remove(bet);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}