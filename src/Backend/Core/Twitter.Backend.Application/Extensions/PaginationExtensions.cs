using Twitter.Backend.Application.Pagination;

namespace Twitter.Backend.Application.Extensions;

public static class PaginationExtensions
{
    public static PaginationResponse<T> GetPaged<T>(this IQueryable<T> query, int size, int page) where T : class
    {
        var count =  query.Count();
        var paging = new PageInfo(page, size,count);

        var data = query.Skip(paging.Skip).Take(paging.PageSize).ToList();

        var result = new PaginationResponse<T>(data, paging);
        return result;
    }
        
}