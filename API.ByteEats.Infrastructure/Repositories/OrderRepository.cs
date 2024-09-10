using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Interfaces.Repositories;
using API.ByteEats.Infrastructure.Repositories.Base;

namespace API.ByteEats.Infrastructure.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    private ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
