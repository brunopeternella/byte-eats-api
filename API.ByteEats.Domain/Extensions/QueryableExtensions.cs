using API.ByteEats.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace API.ByteEats.Domain.Extensions;

public static class QueryableExtensions
{
    public static async Task<PagedResult<T>> ToPagedResultAsync<T>(this IQueryable<T> query, int pageNumber,
        int pageSize) where T : class
    {
        var totalCount = await query.CountAsync();

        var items = await query.Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<T>(items, totalCount, pageNumber, pageSize);
    }
}
