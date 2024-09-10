using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Interfaces.Repositories;
using API.ByteEats.Infrastructure.Repositories.Base;

namespace API.ByteEats.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
