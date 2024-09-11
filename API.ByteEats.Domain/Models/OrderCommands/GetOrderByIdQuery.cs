using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Handlers;
using API.ByteEats.Domain.Models.OrderCommands.Responses;
using MediatR;

namespace API.ByteEats.Domain.Models.OrderCommands;

public class GetOrderByIdQuery : IBaseRequest<OrderResponse>
{
    public Guid Id { get; set; }
}
