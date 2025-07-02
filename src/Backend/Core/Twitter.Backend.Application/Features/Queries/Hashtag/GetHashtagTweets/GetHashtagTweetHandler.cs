using AutoMapper;
using MediatR;
using Twitter.Backend.Application.Features.Queries.Hashtag.GetHashtags;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Queries.Hashtag.GetHashtagTweets;

public class GetHashtagTweetHandler : IRequestHandler<GetHashtagTweetRequest,GetHashtagTweetResponse>
{
    private ITweetHashTagRepository _tweetHashTagRepository;
    private IMapper _mapper;
    

    public GetHashtagTweetHandler( IMapper mapper, ITweetHashTagRepository tweetHashTagRepository)
    {
        _mapper = mapper;
        _tweetHashTagRepository = tweetHashTagRepository;
    }

    public async Task<GetHashtagTweetResponse> Handle(GetHashtagTweetRequest request, CancellationToken cancellationToken)
    {
        var tweets = _tweetHashTagRepository.Get(i => i.HashtagId == request.HashtagId).Select(i=>i.TweetId).ToList();

        return new GetHashtagTweetResponse() { HashtagId = request.HashtagId, HashtagTweetsIds = tweets };
    }
}