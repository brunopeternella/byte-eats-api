using MediatR;

namespace API.ByteEats.Domain.Models;

public class PagedQuery<TEntity> : IRequest<PagedResult<TEntity>> where TEntity : class
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 100;
}
