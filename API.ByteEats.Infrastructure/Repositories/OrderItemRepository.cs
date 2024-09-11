using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Interfaces.Repositories;
using API.ByteEats.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace API.ByteEats.Infrastructure.Repositories;

public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
{
    private ApplicationDbContext _context;

    public OrderItemRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<OrderItem>> GetByOrderAsNoTracking(Guid id)
    {
        return await _context.OrderItems
            .AsNoTracking()
            .Where(oi => oi.OrderId.Equals(id))
            .ToListAsync();
    }

    public async Task<List<OrderItem>> GetByOrder(Guid id)
    {
        return await _context.OrderItems
            .Where(oi => oi.OrderId.Equals(id))
            .ToListAsync();
    }

    public async Task<OrderItem?> GetByOrderAndProduct(Guid orderId, Guid productId)
    {
        return await _context.OrderItems
            .AsNoTracking()
            .Where(oi => oi.OrderId.Equals(orderId) && oi.ProductId.Equals(productId))
            .FirstOrDefaultAsync();
    }
}
