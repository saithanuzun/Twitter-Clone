using System.Text.Json.Serialization;

namespace Twitter.BlazorApp.Pagination;

public class Page
{
    public Page() : this(0)
    {

    }

    public Page(int totalRowCount) :
        this(1, 10, totalRowCount)
    {

    }

    public Page(int pageSize, int totalRowCount) :
        this(1, pageSize, totalRowCount)
    {

    }

    public Page(int currentPage, int pageSize, int totalRowCount)
    {
        if (currentPage < 1)
            throw new ArgumentException("Invalid page number!");

        if (pageSize < 1)
            throw new ArgumentException("Invalid page size!");

        TotalRowCount = totalRowCount;
        CurrentPage = currentPage;
        PageSize = pageSize;
    }

    [JsonPropertyName("currentPage")]
    public int CurrentPage { get; set; }
    

    [JsonPropertyName("pageSize")]
    public int PageSize { get; set; }
    

    [JsonPropertyName("totalRowCount")]
    public int TotalRowCount { get; set; }

    [JsonPropertyName("totalPageCount")]
    public int TotalPageCount => (int)Math.Ceiling((double)TotalRowCount / PageSize);

    [JsonPropertyName("skip")]
    public int Skip => (CurrentPage - 1) * PageSize;
}