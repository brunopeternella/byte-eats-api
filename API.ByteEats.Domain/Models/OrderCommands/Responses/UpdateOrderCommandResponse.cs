using API.ByteEats.Domain.Entities;

namespace API.ByteEats.Domain.Models.OrderCommands;

public class UpdateOrderCommandResponse
{
    /// <summary>
    /// Order ID.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// User ID.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Was order paid.
    /// </summary>
    public bool WasPaid { get; set; }

    /// <summary>
    /// Date time of order creation.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Date time of order update.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    public UpdateOrderCommandResponse(Order order)
    {
        Id = order.Id;
        UserId = order.UserId;
        WasPaid = order.WasPaid;
        CreatedAt = order.CreatedAt;
        UpdatedAt = order.UpdatedAt;
    }
}
