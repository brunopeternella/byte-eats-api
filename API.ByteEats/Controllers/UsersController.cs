using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Models;
using API.ByteEats.Domain.Models.Notification;
using API.ByteEats.Domain.Models.UserCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.ByteEats.Controllers;

public class UsersController : ApiController
{
    public UsersController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// Get an user.
    /// </summary>
    /// <param name="id">User ID.</param>
    /// <returns></returns>
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType<User>(StatusCodes.Status200OK)]
    [ProducesResponseType<NotificationResponseModel>(StatusCodes.Status400BadRequest)]
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

    /// <summary>
    /// Get users using filters.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType<PagedResult<User>>(StatusCodes.Status200OK)]
    [ProducesResponseType<NotificationResponseModel>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetUsers([FromQuery] GetUsersQuery command)
    {
        var users = await Mediator.Send(command);

        if (!users.IsSuccess)
            return BadRequestNotification();

        return Ok(users.Value);
    }

    /// <summary>
    /// Create an user.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType<User>(StatusCodes.Status201Created)]
    [ProducesResponseType<NotificationResponseModel>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
    {
        var user = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetUserById), new { id = user.Value.Id }, user.Value);
    }

    /// <summary>
    /// Update an user.
    /// </summary>
    /// <param name="id">User ID.</param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType<User>(StatusCodes.Status200OK)]
    [ProducesResponseType<NotificationResponseModel>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserCommand command)
    {
        command.Id = id;

        var user = await Mediator.Send(command);

        if (!user.IsSuccess)
            return BadRequestNotification();

        return Ok(user.Value);
    }

    /// <summary>
    /// Delete an user.
    /// </summary>
    /// <param name="id">User ID.</param>
    /// <returns></returns>
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType<User>(StatusCodes.Status200OK)]
    [ProducesResponseType<NotificationResponseModel>(StatusCodes.Status400BadRequest)]
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
