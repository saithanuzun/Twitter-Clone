namespace Twitter.Backend.Application.Pagination;

public class PageInfo
{
    public PageInfo() : this(0)
    {
    }

    public PageInfo(int totalRowCount) : this(1, 10, totalRowCount)
    {
    }

    public PageInfo(int pageSize, int totalRowCount) : this(1, pageSize, totalRowCount)
    {
    }
    public PageInfo(int currentPage, int pageSize, int totalRowCount)
    {
        if (currentPage < 1)
            throw new ArgumentException("Invalid page number!");

        if (pageSize < 1)
            throw new ArgumentException("Invalid page size!");

        TotalRowCount = totalRowCount;
        CurrentPage = currentPage;
        PageSize = pageSize;
    }
    public int CurrentPage { get; set; }

    public int PageSize { get; set; }

    public int TotalRowCount { get; set; }

    public int TotalPageCount => (int)Math.Ceiling((double)TotalRowCount / PageSize);

    public int Skip => (CurrentPage - 1) * PageSize;
}