using MediatR;
using Twitter.Backend.Application.Extensions;
using Twitter.Backend.Application.Pagination;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Queries.Tweet.GetMainPageTweets;

public class
    GetMainPageTweetsHandler : IRequestHandler<GetMainPageTweetsRequest, PaginationResponse<GetMainPageTweetsResponse>>
{
    private ITweetRepository _tweetRepository;

    public GetMainPageTweetsHandler(ITweetRepository tweetRepository)
    {
        _tweetRepository = tweetRepository;
    }
    

    public async Task<PaginationResponse<GetMainPageTweetsResponse>> Handle(GetMainPageTweetsRequest request, CancellationToken cancellationToken)
    {
        var TweetsQuery = _tweetRepository.AsQueryable().GetPaged(request.PageSize,request.Page).Result;

        return new PaginationResponse<GetMainPageTweetsResponse>(TweetsQuery.ToList(),new PageInfo(request.PageSize,request.Page) );

    }
}


   