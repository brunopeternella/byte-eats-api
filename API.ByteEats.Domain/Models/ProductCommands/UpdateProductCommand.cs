using System.Text.Json.Serialization;
using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Handlers;
using MediatR;

namespace API.ByteEats.Domain.Models.ProductCommands;

public class UpdateProductCommand : IBaseRequest<Product>
{
    [JsonIgnore] public Guid Id { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public int? Serves { get; set; }
}
