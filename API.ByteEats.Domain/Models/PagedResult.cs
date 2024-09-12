namespace API.ByteEats.Domain.Models;

public class PagedResult<TEntity> where TEntity : class
{
    public PagedResult(List<TEntity> items, int totalCount, int page, int pageSize)
    {
        Items = items;
        TotalCount = totalCount;
        Page = page;
        PageSize = pageSize;
    }

    /// <summary>
    /// Total items that matches the query.
    /// </summary>
    public int TotalCount { get; }

    /// <summary>
    /// Actual page.
    /// </summary>
    public int Page { get; }

    /// <summary>
    /// Actual page size.
    /// </summary>
    public int PageSize { get; }

    /// <summary>
    /// Total pages.
    /// Math Ceiling: TotalCount/PageSize
    /// </summary>
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

    /// <summary>
    /// Control property to show if has more items to query.
    /// </summary>
    public bool HasNext => Page < TotalPages;

    public List<TEntity> Items { get; }
}
