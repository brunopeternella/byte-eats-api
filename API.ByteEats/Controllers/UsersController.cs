using API.ByteEats.Domain.Models.UserCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.ByteEats.Controllers;

public class UsersController : ApiController
{
    public UsersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetUserById([FromRoute] Guid id)
    {
        var command = new GetUserByIdQuery
        {
            Id = id
        };

        var user = await Mediator.Send(command);

        if (!user.IsSuccess)
            return BadRequestNotification();

        return Ok(user.Value);
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers([FromQuery] GetUsersQuery command)
    {
        var users = await Mediator.Send(command);

        if (!users.IsSuccess)
            return BadRequestNotification();

        return Ok(users.Value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
    {
        var user = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetUserById), new { id = user.Value.Id }, user.Value);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserCommand command)
    {
        command.Id = id;

        var user = await Mediator.Send(command);

        if (!user.IsSuccess)
            return BadRequestNotification();

        return Ok(user.Value);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
    {
        var command = new DeleteUserCommand
        {
            Id = id
        };

        var user = await Mediator.Send(command);

        if (!user.IsSuccess)
            return BadRequestNotification();

        return Ok(user.Value);
    }

}
