namespace API.ByteEats.Domain.DTOs;

public class OrderItemRequestDTO
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
