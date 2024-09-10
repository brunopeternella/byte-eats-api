using API.ByteEats.Domain.Models.ProductCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.ByteEats.Controllers;

public class ProductsController : ApiController
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetProductById([FromRoute] Guid id)
    {
        var command = new GetProductByIdQuery
        {
            Id = id
        };

        var product = await _mediator.Send(command);

        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] GetProductsQuery command)
    {
        var products = await _mediator.Send(command);

        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        var product = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductCommand command)
    {
        command.Id = id;

        var product = await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
    {
        var command = new DeleteProductCommand();
        command.Id = id;

        var product = await _mediator.Send(command);

        return NoContent();
    }
}