using API.ByteEats.Domain.DTOs;
using MediatR;

namespace API.ByteEats.Domain.Models.OrderCommands;

public class CreateOrderCommand : IRequest<CreateOrderCommandResponse>
{
    public Guid UserId { get; set; }

    public List<OrderItemRequestDTO> Items { get; set; }
}