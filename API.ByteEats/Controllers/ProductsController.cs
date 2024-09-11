using API.ByteEats.Domain.Models.ProductCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.ByteEats.Controllers;

public class ProductsController : ApiController
{
    public ProductsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("{id}")]
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

    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] GetProductsQuery command)
    {
        var products = await Mediator.Send(command);

        if (!products.IsSuccess)
            return BadRequestNotification();

        return Ok(products.Value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        var product = await Mediator.Send(command);

        if (!product.IsSuccess)
            return BadRequestNotification();

        return CreatedAtAction(nameof(GetProductById), new { id = product.Value.Id }, product.Value);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductCommand command)
    {
        command.Id = id;

        var product = await Mediator.Send(command);

        if (!product.IsSuccess)
            return BadRequestNotification();

        return Ok(product.Value);
    }

    [HttpDelete]
    [Route("{id}")]
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
