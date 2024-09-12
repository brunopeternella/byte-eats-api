using API.ByteEats.Domain.Entities;

namespace API.ByteEats.Domain.DTOs;

public class OrderItemResponseDTO
{
    /// <summary>
    /// Order item ID.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Product ID.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Product name.
    /// </summary>
    public string ProductName { get; set; }

    /// <summary>
    /// Product price.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Product quantity.
    /// </summary>
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
