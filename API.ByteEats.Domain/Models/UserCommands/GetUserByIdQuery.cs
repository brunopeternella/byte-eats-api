using API.ByteEats.Domain.Entities;
using MediatR;

namespace API.ByteEats.Domain.Models.UserCommands;

public class GetUserByIdQuery : IRequest<User>
{
    public Guid Id { get; set; }
}