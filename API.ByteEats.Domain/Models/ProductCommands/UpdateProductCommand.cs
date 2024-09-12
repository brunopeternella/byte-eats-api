using System.Text.Json.Serialization;
using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Handlers;
using MediatR;

namespace API.ByteEats.Domain.Models.ProductCommands;

public class UpdateProductCommand : IBaseRequest<Product>
{
    [JsonIgnore] public Guid Id { get; set; }

    /// <summary>
    /// Product name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Product description.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Product price.
    /// </summary>
    public decimal? Price { get; set; }

    /// <summary>
    /// How many people can be served.
    /// </summary>
    public int? Serves { get; set; }
}
