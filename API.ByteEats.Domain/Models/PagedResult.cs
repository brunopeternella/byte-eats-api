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

    public int TotalCount { get; }
    public int Page { get; }
    public int PageSize { get; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public bool HasNext => Page < TotalPages;
    public List<TEntity> Items { get; }
}
