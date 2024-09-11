using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Handlers;
using MediatR;

namespace API.ByteEats.Domain.Models.ProductCommands;

public class DeleteProductCommand : IBaseRequest<Product>
{
    public Guid Id { get; set; }
}
