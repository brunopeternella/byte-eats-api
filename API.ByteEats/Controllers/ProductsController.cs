using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Models;
using API.ByteEats.Domain.Models.Notification;
using API.ByteEats.Domain.Models.ProductCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.ByteEats.Controllers;

public class ProductsController : ApiController
{
    public ProductsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// Get an product.
    /// </summary>
    /// <param name="id">Product ID.</param>
    /// <returns></returns>
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType<Product>(StatusCodes.Status200OK)]
    [ProducesResponseType<NotificationResponseModel>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetProductById([FromRoute] Guid id)
    {
        var command = new GetProductByIdQuery
        {
            Id = id
        };

        var product = await Mediator.Send(command);

        if (!product.IsSuccess)
            return BadRequestNotification();

        return Ok(product.Value);
    }

    /// <summary>
    /// Get products using filters.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType<PagedResult<Product>>(StatusCodes.Status200OK)]
    [ProducesResponseType<NotificationResponseModel>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetProducts([FromQuery] GetProductsQuery command)
    {
        var products = await Mediator.Send(command);

        if (!products.IsSuccess)
            return BadRequestNotification();

        return Ok(products.Value);
    }

    /// <summary>
    /// Create an product.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType<Product>(StatusCodes.Status201Created)]
    [ProducesResponseType<NotificationResponseModel>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        var product = await Mediator.Send(command);

        if (!product.IsSuccess)
            return BadRequestNotification();

        return CreatedAtAction(nameof(GetProductById), new { id = product.Value.Id }, product.Value);
    }

    /// <summary>
    /// Update an product.
    /// </summary>
    /// <param name="id">Product ID.</param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType<Product>(StatusCodes.Status200OK)]
    [ProducesResponseType<NotificationResponseModel>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductCommand command)
    {
        command.Id = id;

        var product = await Mediator.Send(command);

        if (!product.IsSuccess)
            return BadRequestNotification();

        return Ok(product.Value);
    }

    /// <summary>
    /// Delete an product.
    /// </summary>
    /// <param name="id">Product ID.</param>
    /// <returns></returns>
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType<Product>(StatusCodes.Status200OK)]
    [ProducesResponseType<NotificationResponseModel>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
    {
        var command = new DeleteProductCommand
        {
            Id = id
        };

        var product = await Mediator.Send(command);

        if (!product.IsSuccess)
            return BadRequestNotification();

        return Ok(product.Value);
    }
}
