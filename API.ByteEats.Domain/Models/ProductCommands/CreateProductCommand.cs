using API.ByteEats.Domain.Entities;
using MediatR;

namespace API.ByteEats.Domain.Models.ProductCommands;

public class CreateProductCommand : IRequest<Product>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Serves { get; set; }
}