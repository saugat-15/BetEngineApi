using Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Bets.Queries;


namespace API.Controllers;

public class BetsController: BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Bets>>> GetBets()
    {
        return await Mediator.Send(new GetBets.Query());
    }
}