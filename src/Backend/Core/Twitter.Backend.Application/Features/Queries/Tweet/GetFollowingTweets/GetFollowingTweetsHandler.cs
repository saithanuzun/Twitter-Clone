using MediatR;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Queries.Tweet.GetFollowingTweets;

public class GetFollowingTweetsHandler: IRequestHandler<GetFollowingTweetsRequest,GetFollowingTweetsResponse>
{
    private ITweetRepository _tweetRepository;

    public GetFollowingTweetsHandler(ITweetRepository tweetRepository)
    {
        _tweetRepository = tweetRepository;
    }

    // todo: impelemnt following feed
    public Task<GetFollowingTweetsResponse> Handle(GetFollowingTweetsRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}