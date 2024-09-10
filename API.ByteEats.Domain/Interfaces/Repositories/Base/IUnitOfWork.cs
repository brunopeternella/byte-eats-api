namespace API.ByteEats.Domain.Interfaces.Repositories.Base;

public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }
    IUserRepository Users { get; }
    IOrderItemRepository OrderItems { get; }
    IOrderRepository Orders { get; }
    Task<int> SaveAsync();
}