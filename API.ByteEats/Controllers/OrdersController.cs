using System.Net;
using API.ByteEats.Domain.Models;
using API.ByteEats.Domain.Models.Notification;
using API.ByteEats.Domain.Models.OrderCommands;
using API.ByteEats.Domain.Models.OrderCommands.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.ByteEats.Controllers;

public class OrdersController : ApiController
{
    public OrdersController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// Get an order by ID.
    /// </summary>
    /// <param name="id">Order ID</param>
    /// <returns></returns>
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType<OrderResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<NotificationResponseModel>(StatusCodes.Status400BadRequest)]
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

    /// <summary>
    /// Get orders using filters.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType<PagedResult<OrderResponse>>(StatusCodes.Status200OK)]
    [ProducesResponseType<NotificationResponseModel>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetOrders([FromQuery] GetOrdersQuery command)
    {
        var orders = await Mediator.Send(command);

        return Ok(orders.Value);
    }

    /// <summary>
    /// Create an order.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType<OrderResponse>(StatusCodes.Status201Created)]
    [ProducesResponseType<NotificationResponseModel>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
    {
        var order = await Mediator.Send(command);

        if (!order.IsSuccess)
            return BadRequestNotification();

        return CreatedAtAction(nameof(GetOrderById), new { id = order.Value.Id }, order.Value);
    }

    /// <summary>
    /// Update an order.
    /// </summary>
    /// <param name="id">Order ID.</param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType<UpdateOrderCommandResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<NotificationResponseModel>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateOrder([FromRoute] Guid id, [FromBody] UpdateOrderCommand command)
    {
        command.Id = id;

        var order = await Mediator.Send(command);

        if (!order.IsSuccess)
            return BadRequestNotification();

        return Ok(order.Value);
    }

    /// <summary>
    /// Delete an order.
    /// </summary>
    /// <param name="id">Order ID.</param>
    /// <returns></returns>
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType<OrderResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<NotificationResponseModel>(StatusCodes.Status400BadRequest)]
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
