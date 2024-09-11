using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Interfaces.Repositories;
using API.ByteEats.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace API.ByteEats.Infrastructure.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    private ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Order?> GetByIdWithUserAsNoTracking(Guid id)
    {
        return await _context.Orders
            .AsNoTracking()
            .Where(o => o.Id.Equals(id))
            .Include(i => i.User)
            .FirstOrDefaultAsync();
    }
}
