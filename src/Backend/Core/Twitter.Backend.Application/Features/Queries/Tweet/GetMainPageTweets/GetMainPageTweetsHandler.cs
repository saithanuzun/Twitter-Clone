using MediatR;
using Twitter.Backend.Application.Extensions;
using Twitter.Backend.Application.Pagination;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Queries.Tweet.GetMainPageTweets;

public class
    GetMainPageTweetsHandler : IRequestHandler<PaginationResponse<GetMainPageTweetsRequest>, GetMainPageTweetsResponse>
{
    private ITweetRepository _tweetRepository;

    public GetMainPageTweetsHandler(ITweetRepository tweetRepository)
    {
        _tweetRepository = tweetRepository;
    }

    public Task<GetMainPageTweetsResponse> Handle(PaginationResponse<GetMainPageTweetsRequest> request, CancellationToken cancellationToken)
    {
        var TweetsQuery = _tweetRepository.AsQueryable();

        TweetsQuery = TweetsQuery.GetPaged(request.PageInfo.PageSize, request.PageInfo.CurrentPage);
    }
}


   