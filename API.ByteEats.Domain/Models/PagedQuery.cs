using API.ByteEats.Domain.Handlers;
using MediatR;

namespace API.ByteEats.Domain.Models;

public class PagedQuery<TEntity> : IBaseRequest<PagedResult<TEntity>> where TEntity : class
{
    /// <summary>
    /// Default: 1
    /// </summary>
    public int Page { get; set; } = 1;

    /// <summary>
    /// Default: 100
    /// </summary>
    public int PageSize { get; set; } = 100;
}
