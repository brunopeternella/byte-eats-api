using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Handlers;
using MediatR;

namespace API.ByteEats.Domain.Models.UserCommands;

public class GetUserByIdQuery : IBaseRequest<User>
{
    public Guid Id { get; set; }
}
