using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Interfaces.Repositories.Base;

namespace API.ByteEats.Domain.Interfaces.Repositories;

public interface IOrderItemRepository : IRepository<OrderItem>
{
    Task<List<OrderItem>> GetByOrderAsNoTracking(Guid id);
    Task<List<OrderItem>> GetByOrder(Guid id);
    Task<OrderItem> GetByOrderAndProduct(Guid orderId, Guid productId);
}
