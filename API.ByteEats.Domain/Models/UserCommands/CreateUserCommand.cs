using API.ByteEats.Domain.Entities;
using MediatR;

namespace API.ByteEats.Domain.Models.UserCommands;

public class CreateUserCommand : IRequest<User>
{
    public string Name { get; set; }
    public string Email { get; set; }
}