
using EventMenagement.Web.response;

namespace EventMenagement.Web.Extensions;

public  static class PaginateResponseExtension
{
    public static PaginatedResponse<TResult> ToPaginateResponse<T, TResult>(
        this PaginatedResponse<T> response,
        Func<T, TResult> mappingFunc)
    {
        return new PaginatedResponse<TResult>
        {
            Items = response.Items.Select(mappingFunc).ToList(),
            TotalCount = response.TotalCount,
            PageNumbet = response.PageNumbet,
            PageSize = response.PageSize,
            TotalPages = response.TotalPages
        };
    }
}