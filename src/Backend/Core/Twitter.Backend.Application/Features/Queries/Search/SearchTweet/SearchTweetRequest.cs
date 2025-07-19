using MediatR;

namespace Twitter.Backend.Application.Features.Queries.Search.SearchTweet;

public class SearchTweetRequest : IRequest<List<SearchTweetResponse>>
{
    public string SearchItem { get; set; }
}