using API.ByteEats.Domain.DTOs;
using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Enums;

namespace API.ByteEats.Domain.Models.OrderCommands.Responses;

public class OrderResponse
{
    /// <summary>
    /// Order ID.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// User name.
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// User email.
    /// </summary>
    public string UserEmail { get; set; }

    /// <summary>
    /// Was order paid.
    /// </summary>
    public bool WasPaid { get; set; }

    /// <summary>
    /// Total order value. <br/>
    /// Sum of all products price * order item quantity.
    /// </summary>
    public decimal TotalValue { get; set; }

    /// <summary>
    /// Date time of order creation.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Date time of order update.
    /// </summary>
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
