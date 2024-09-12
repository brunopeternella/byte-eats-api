using API.ByteEats.Domain.DTOs;
using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Enums;

namespace API.ByteEats.Domain.Models.OrderCommands.Responses;

public class OrderResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public bool WasPaid { get; set; }
    public decimal TotalValue { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public OrderStatus Status { get; set; }
    public IEnumerable<OrderItemResponseDTO> Items { get; set; }

    public OrderResponse(Order order, IEnumerable<OrderItem> orderItems)
    {
        Id = order.Id;
        UserName = order.User.Name;
        UserEmail = order.User.Email;
        WasPaid = order.WasPaid;
        TotalValue = GetTotalValue(orderItems);
        CreatedAt = order.CreatedAt;
        UpdatedAt = order.UpdatedAt;
        Items = GetOrderItemsResponse(orderItems);
        Status = order.Status;
    }

    private decimal GetTotalValue(IEnumerable<OrderItem> orderItems)
    {
        return orderItems
            .Sum(item => (decimal)item.Quantity * item.Product.Price);
    }

    private IEnumerable<OrderItemResponseDTO> GetOrderItemsResponse(IEnumerable<OrderItem> orderItems)
    {
        return orderItems.Select(item => new OrderItemResponseDTO(item));
    }
}
