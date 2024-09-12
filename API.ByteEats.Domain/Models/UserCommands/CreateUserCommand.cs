using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Handlers;
using MediatR;

namespace API.ByteEats.Domain.Models.UserCommands;

public class CreateUserCommand : IBaseRequest<User>
{
    /// <summary>
    /// User name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// User email.
    /// </summary>
    public string Email { get; set; }
}
