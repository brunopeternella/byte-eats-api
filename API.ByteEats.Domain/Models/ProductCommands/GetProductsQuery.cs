using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Enums;

namespace API.ByteEats.Domain.Models.ProductCommands;

public class GetProductsQuery : PagedQuery<Product>
{
    public ProductCategory? Category { get; set; }
    public ProductPromotion? Promotion { get; set; }
}
