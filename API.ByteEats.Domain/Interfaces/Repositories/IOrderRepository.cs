using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Interfaces.Repositories.Base;

namespace API.ByteEats.Domain.Interfaces.Repositories;

public interface IOrderRepository : IRepository<Order>
{
    public Task<Order?> GetByIdWithUserAsNoTracking(Guid id);
}
