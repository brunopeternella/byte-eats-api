using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Enums;
using API.ByteEats.Domain.Models.OrderCommands.Responses;

namespace API.ByteEats.Domain.Models.OrderCommands;

public class GetOrdersQuery : PagedQuery<OrderResponse>
{
}
