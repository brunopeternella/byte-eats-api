using API.ByteEats.Domain.DTOs;

namespace API.ByteEats.Domain.Models.OrderCommands;

public class CreateOrderCommandResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public bool WasPaid { get; set; }
    public decimal TotalValue { get; set; }
    public List<OrderItemResponseDTO> Items { get; set; }
}