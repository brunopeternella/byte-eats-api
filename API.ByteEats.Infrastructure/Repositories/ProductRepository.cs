using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Interfaces.Repositories;
using API.ByteEats.Domain.Models;
using API.ByteEats.Infrastructure.Repositories.Base;

namespace API.ByteEats.Infrastructure.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
