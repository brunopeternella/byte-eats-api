using API.ByteEats.Domain.Models.UserCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.ByteEats.Controllers;

public class UsersController : ApiController
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetUserById([FromRoute] Guid id)
    {
        var command = new GetUserByIdQuery
        {
            Id = id
        };

        var user = await _mediator.Send(command);

        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers([FromQuery] GetUsersQuery command)
    {
        var users = await _mediator.Send(command);

        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
    {
        var user = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserCommand command)
    {
        command.Id = id;

        var user = await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
    {
        var command = new DeleteUserCommand();
        command.Id = id;

        var user = await _mediator.Send(command);

        return NoContent();
    }
}