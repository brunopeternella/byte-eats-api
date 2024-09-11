using System.Text.Json.Serialization;
using API.ByteEats.Domain.DTOs;
using API.ByteEats.Domain.Handlers;
using MediatR;

namespace API.ByteEats.Domain.Models.OrderCommands;

public class UpdateOrderCommand : IBaseRequest<UpdateOrderCommandResponse>
{
    [JsonIgnore]
    public Guid Id { get; set; }

    public bool? WasPaid { get; set; }
}
