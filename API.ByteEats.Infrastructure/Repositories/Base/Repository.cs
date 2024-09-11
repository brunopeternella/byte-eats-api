using System.Linq.Expressions;
using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Extensions;
using API.ByteEats.Domain.Interfaces.Repositories.Base;
using API.ByteEats.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.ByteEats.Infrastructure.Repositories.Base;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TEntity?> GetById(Guid id)
    {
        return await _context.Set<TEntity>()
            .FirstOrDefaultAsync(t => t.Id.Equals(id));
    }

    public async Task<TEntity?> GetByIdAsNoTracking(Guid id)
    {
        return await _context.Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id.Equals(id));
    }

    public async Task<PagedResult<TEntity>> GetPagedByFilter(int page, int pageSize,
        IEnumerable<Expression<Func<TEntity, bool>>> filters = null,
        Expression<Func<TEntity, object>> orderBy = null,
        bool ascending = true)
    {
        var query = _context.Set<TEntity>().AsQueryable();

        if (filters != null && filters.Any())
        {
            var combinedFilter = filters.Aggregate((current, next) =>
                current.And(next));

            query = query.Where(combinedFilter);
        }

        if (orderBy != null)
        {
            query = ascending ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);
        }

        var totalCount = await query.CountAsync();
        var items = await query
            .AsNoTracking()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<TEntity>(items, totalCount, page, pageSize);
    }

    public async ValueTask<EntityEntry<TEntity>> Create(TEntity entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = null;

        return await _context.Set<TEntity>().AddAsync(entity);
    }

    public EntityEntry<TEntity> Update(TEntity entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;

        return _context.Set<TEntity>().Update(entity);
    }

    public EntityEntry<TEntity> Delete(TEntity entity)
    {
        return _context.Set<TEntity>().Remove(entity);
    }

    public async Task<EntityEntry<TEntity>?> Delete(Guid id)
    {
        var entity = await GetById(id);

        return entity is null ? null : _context.Set<TEntity>().Remove(entity);
    }
}
