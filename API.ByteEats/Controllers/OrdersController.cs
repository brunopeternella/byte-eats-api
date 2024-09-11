using API.ByteEats.Domain.Models.OrderCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.ByteEats.Controllers;

public class OrdersController : ApiController
{
    public OrdersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOrderById([FromRoute] Guid id)
    {
        var command = new GetOrderByIdQuery
        {
            Id = id
        };

        var order = await Mediator.Send(command);

        if (!order.IsSuccess)
            return BadRequestNotification();

        return Ok(order.Value);
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders([FromQuery] GetOrdersQuery command)
    {
        var orders = await Mediator.Send(command);

        return Ok(orders.Value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
    {
        var order = await Mediator.Send(command);

        if (!order.IsSuccess)
            return BadRequestNotification();

        return CreatedAtAction(nameof(GetOrderById), new { id = order.Value.Id }, order.Value);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateOrder([FromRoute] Guid id, [FromBody] UpdateOrderCommand command)
    {
        command.Id = id;

        var order = await Mediator.Send(command);

        if (!order.IsSuccess)
            return BadRequestNotification();

        return Ok(order.Value);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteOrder([FromRoute] Guid id)
    {
        var command = new DeleteOrderCommand
        {
            Id = id
        };

        var order = await Mediator.Send(command);

        if (!order.IsSuccess)
            return BadRequestNotification();

        return Ok(order.Value);
    }


}
