namespace EventMenagement.Web.response;

public record PaginatedResponse<T>
{
    public List<T> Items { get; set; } = new();
    public int TotalCount { get; set; }
    public int PageNumbet { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    
    public bool HasPreviousPage => PageNumbet > 0;
    public bool HasNextPage => PageNumbet < TotalPages-1;
}