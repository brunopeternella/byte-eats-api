using API.ByteEats.Domain.Entities;

namespace API.ByteEats.Domain.Models.OrderCommands;

public class UpdateOrderCommandResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public bool WasPaid { get; set; }
    public DateTime CreatedAt { get; set; }
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
