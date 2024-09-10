namespace API.ByteEats.Domain.DTOs;

public class OrderItemResponseDTO
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal UnitValue { get; set; }
    public int Quantity { get; set; }
}