using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Interfaces.Repositories;
using API.ByteEats.Infrastructure.Repositories.Base;

namespace API.ByteEats.Infrastructure.Repositories;

public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
{
    private ApplicationDbContext _context;

    public OrderItemRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
