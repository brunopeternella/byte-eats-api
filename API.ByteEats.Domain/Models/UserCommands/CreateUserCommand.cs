using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Handlers;
using MediatR;

namespace API.ByteEats.Domain.Models.UserCommands;

public class CreateUserCommand : IBaseRequest<User>
{
    public string Name { get; set; }
    public string Email { get; set; }
}
