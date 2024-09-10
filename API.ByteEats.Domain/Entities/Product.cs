using API.ByteEats.Domain.Enums;

namespace API.ByteEats.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Serves { get; set; }
    public ProductCategory Category { get; set; }
    public ProductPromotion Promotion { get; set; }
}
