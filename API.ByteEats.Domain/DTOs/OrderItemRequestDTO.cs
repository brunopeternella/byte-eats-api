using System.ComponentModel.DataAnnotations;

namespace API.ByteEats.Domain.DTOs;

/// <summary>
/// Order items.
/// </summary>
public class OrderItemRequestDTO
{
    /// <summary>
    /// Product ID.
    /// </summary>
    [Required]
    public Guid ProductId { get; set; }

    /// <summary>
    /// Product quantity.
    /// </summary>
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "The value must be greater than zero.")]
    public int Quantity { get; set; }
}
