using Application.Bets.Commands;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Bets.Queries;


namespace API.Controllers;

public class BetsController: BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Bet>>> GetBets()
    {
        return await Mediator.Send(new GetBets.Query());
    }
    
    [HttpGet("{id}")]
    public async Task<Bet> GetBetDetails(Guid id)
    {
        return await Mediator.Send(new GetBetDetails.Query{Id=id});
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateBet(
        Bet bet,
        [FromHeader(Name = "Idempotency-Key")] string? idempotencyKey)
    {
        bet.IdempotencyKey = idempotencyKey ?? Guid.NewGuid().ToString();
        var betId = await Mediator.Send(new CreateBet.Command { Bet = bet });
        return CreatedAtAction(nameof(GetBetDetails), new { id = betId }, betId);
    }
}