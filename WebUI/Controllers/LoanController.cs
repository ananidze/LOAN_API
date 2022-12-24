using Application.Loan.Commands.ChangeStatus;
using Application.Loan.Commands.CreateLoan;
using Application.Loan.Commands.DeleteLoan;
using Application.Loan.Commands.UpdateLoan;
using Application.Loan.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoanController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Loan>>> Get()
    {
        return Ok(await Mediator.Send(new GetLoanQuery()));
    }
    
    [HttpPost]
    public async Task<ActionResult<Loan>> Create(CreateLoanCommand command)
    {
        await Mediator.Send(command);
        return Created("api/loan", command);
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Loan>> Get(int id)
    {
        return Ok(await Mediator.Send(new GetLoanByUserId(id)));
    }
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteLoanCommand(id));
        return Ok("Loan deleted");
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<Loan>> Update(int id, UpdateLoanCommand command)
    {
        var loan = await Mediator.Send(new UpdateLoanCommand(id));
        return Ok(command);
    }
    
    [HttpPost("status")]
    public async Task<ActionResult<Loan>> UpdateStatus(UpdateLoanStatusCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }
}
