using API.ByteEats.Domain.Interfaces.Repositories;
using API.ByteEats.Domain.Interfaces.Repositories.Base;

namespace API.ByteEats.Infrastructure.Repositories.Base;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    private bool _disposed;

    private IOrderItemRepository _orderItems;
    private IOrderRepository _orderRepository;
    private IProductRepository _productRepository;
    private IUserRepository _userRepository;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IProductRepository Products => _productRepository ??= new ProductRepository(_context);
    public IUserRepository Users => _userRepository ??= new UserRepository(_context);
    public IOrderItemRepository OrderItems => _orderItems ??= new OrderItemRepository(_context);
    public IOrderRepository Orders => _orderRepository ??= new OrderRepository(_context);

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                _context.Dispose();
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
