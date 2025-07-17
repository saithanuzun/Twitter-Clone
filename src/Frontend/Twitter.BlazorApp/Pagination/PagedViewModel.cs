using System.Text.Json.Serialization;

namespace Twitter.BlazorApp.Pagination;

public class PagedViewModel<T> where T: class
{
    public PagedViewModel(): this(new List<T>(), new Page())
    {

    }

    public PagedViewModel(IList<T> results, Page pageInfo)
    {
        Results = results;
        PageInfo = pageInfo;
    }

    [JsonPropertyName("result")]
    public IList<T> Results { get; set; }

    [JsonPropertyName("pageInfo")]
    public Page PageInfo { get; set; }
}