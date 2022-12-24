using Application.User.Commands;
using Application.User.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController: ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
        return Ok(await Mediator.Send(new GetUserQuery()));
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<User>> Get(int id)
    {
        var user = await Mediator.Send(new GetUserByIdQuery(id));
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
    
    [HttpPost]
    public async Task<ActionResult<User>> Post([FromBody] CreateUserCommand command)
    {
        await Mediator.Send(command);
        return Created($"/api/user/{User}", command);
    }
    
}