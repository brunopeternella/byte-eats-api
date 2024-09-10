using API.ByteEats.Domain.Entities;
using MediatR;

namespace API.ByteEats.Domain.Models.ProductCommands;

public class DeleteProductCommand : IRequest<Product>
{
    public Guid Id { get; set; }
}