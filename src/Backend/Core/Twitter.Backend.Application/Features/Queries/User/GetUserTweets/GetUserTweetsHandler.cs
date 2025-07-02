using AutoMapper;
using MediatR;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Queries.User.GetUserTweets;

public class GetUserTweetHandler : IRequestHandler<GetUserTweetsRequest,GetUserTweetsResponse>
{
    private ITweetRepository _tweetRepository;
    private IMapper _mapper;

    public GetUserTweetHandler(ITweetRepository tweetRepository, IMapper mapper)
    {
        _tweetRepository = tweetRepository;
        _mapper = mapper;
    }

    public async Task<GetUserTweetsResponse> Handle(GetUserTweetsRequest request, CancellationToken cancellationToken)
    {
        var tweets =  _tweetRepository.Get(i => i.UserId == request.UserId).ToList();

        return new GetUserTweetsResponse() { UserId = request.UserId, Tweets = tweets };
    }
}