using API.ByteEats.Domain.Models.OrderCommands;
using API.ByteEats.Domain.Models.ProductCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.ByteEats.Controllers;

public class OrdersController : ApiController
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOrderById([FromRoute] Guid id)
    {
        var command = new GetProductByIdQuery
        {
            Id = id
        };

        var order = await _mediator.Send(command);

        return Ok(order);
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders([FromQuery] GetProductsQuery command)
    {
        var orders = await _mediator.Send(command);

        return Ok(orders);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
    {
        var order = await _mediator.Send(command);

        if (order is null)
            return NoContent();

        return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateOrder([FromRoute] Guid id, [FromBody] UpdateProductCommand command)
    {
        command.Id = id;

        var order = await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteOrder([FromRoute] Guid id)
    {
        var command = new DeleteProductCommand();
        command.Id = id;

        var order = await _mediator.Send(command);

        return NoContent();
    }
}