using MediatR;

namespace API.ByteEats.Domain.Models.UserCommands;

public class DeleteUserCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}