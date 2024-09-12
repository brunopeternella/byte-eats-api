using System.ComponentModel.DataAnnotations;
using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Handlers;
using MediatR;

namespace API.ByteEats.Domain.Models.ProductCommands;

public class CreateProductCommand : IBaseRequest<Product>
{
    /// <summary>
    /// Product name.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Product description.
    /// </summary>
    [Required]
    public string Description { get; set; }

    /// <summary>
    /// Product price.
    /// </summary>
    [Required]
    public decimal Price { get; set; }

    /// <summary>
    /// How many people can be served.
    /// </summary>
    [Required]
    public int Serves { get; set; }
}
