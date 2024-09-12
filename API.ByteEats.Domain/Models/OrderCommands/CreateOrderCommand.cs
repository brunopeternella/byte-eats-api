using System.ComponentModel.DataAnnotations;
using API.ByteEats.Domain.DTOs;
using API.ByteEats.Domain.Enums;
using API.ByteEats.Domain.Handlers;
using API.ByteEats.Domain.Models.OrderCommands.Responses;
using MediatR;

namespace API.ByteEats.Domain.Models.OrderCommands;

public class CreateOrderCommand : IBaseRequest<OrderResponse>
{
    /// <summary>
    /// User ID.
    /// </summary>
    [Required]
    public Guid UserId { get; set; }

    /// <summary>
    /// Status of the order.
    /// Default: 1 (New order)
    /// </summary>
    public OrderStatus? Status { get; set; }

    [Required]
    public List<OrderItemRequestDTO> Items { get; set; }
}
