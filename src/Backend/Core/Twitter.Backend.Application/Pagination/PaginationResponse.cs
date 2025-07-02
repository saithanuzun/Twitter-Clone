using MediatR;
using Twitter.Backend.Application.Features.Queries.Tweet.GetMainPageTweets;

namespace Twitter.Backend.Application.Pagination;

public class PaginationResponse<T> : IRequest<GetMainPageTweetsResponse> where T : class
{
    public PaginationResponse() : this (new List<T>(),new PageInfo())
    {
        
    }

    public PaginationResponse(IList<T> result, PageInfo pageInfo)
    {
        Result = result;
        PageInfo = pageInfo;
    }

    public IList<T> Result { get; set; }
    public PageInfo PageInfo { get; set; }
}

    