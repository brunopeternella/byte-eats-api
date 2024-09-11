namespace API.ByteEats.Domain.DTOs;

public class UpdateOrderItemRequestDTO
{
    public Guid Id { get; set; }
    public Guid? ProductId { get; set; }
    public int? Quantity { get; set; }
}
