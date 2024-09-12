using API.ByteEats.Domain.DTOs;
using API.ByteEats.Domain.Enums;
using API.ByteEats.Domain.Handlers;
using API.ByteEats.Domain.Models.OrderCommands.Responses;
using MediatR;

namespace API.ByteEats.Domain.Models.OrderCommands;

public class CreateOrderCommand : IBaseRequest<OrderResponse>
{
    public Guid UserId { get; set; }
    public OrderStatus? Status { get; set; }

    public List<OrderItemRequestDTO> Items { get; set; }
}
