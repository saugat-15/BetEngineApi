using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Bets.Commands;

public class EditBet
{
    public class Command : IRequest<string>
    {
        public required Bet Bet { get; set; }
    }

    public class Handler(BetEngineDbContext context, IMapper mapper) : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            var bet = await context.Bet.FindAsync([request.Bet.Id], cancellationToken);
            if(bet == null) return "Bet not found";
            mapper.Map(request.Bet, bet);
            await context.SaveChangesAsync(cancellationToken);
            return bet.Id.ToString();
        }
    }


}