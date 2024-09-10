using System.Linq.Expressions;
using API.ByteEats.Domain.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.ByteEats.Domain.Interfaces.Repositories.Base;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity?> GetById(Guid id);
    Task<TEntity?> GetByIdAsNoTracking(Guid id);
    //Task<PagedResult<TEntity>> GetAll(int pageNumber, int pageSize);
    Task<PagedResult<TEntity>> GetAll(int page, int pageSize,
        IEnumerable<Expression<Func<TEntity, bool>>> filters = null,
        Expression<Func<TEntity, object>> orderBy = null,
        bool ascending = true);
    ValueTask<EntityEntry<TEntity>> Create(TEntity entity);
    EntityEntry<TEntity> Update(TEntity entity);
    EntityEntry<TEntity> Delete(TEntity entity);
    Task<EntityEntry<TEntity>?> Delete(Guid id);
}
