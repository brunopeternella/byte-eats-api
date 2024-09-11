using API.ByteEats.Domain.Entities;

namespace API.ByteEats.Domain.DTOs;

public class OrderItemResponseDTO
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public OrderItemResponseDTO(OrderItem orderItem)
    {
        Id = orderItem.Id;
        ProductId = orderItem.ProductId;
        ProductName = orderItem.Product.Name;
        Price = orderItem.Product.Price;
        Quantity = orderItem.Quantity;
    }
}
