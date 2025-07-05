using AutoMapper;
using MediatR;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Queries.Tweet.GetReplies;

public class GetRepliesHandler : IRequestHandler<GetRepliesRequest,GetRepliesResponse>
{
    private ITweetRepository _tweetRepository;
    private IMapper _mapper;

    public GetRepliesHandler(IMapper mapper, ITweetRepository tweetRepository)
    {
        _mapper = mapper;
        _tweetRepository = tweetRepository;
    }

    public async Task<GetRepliesResponse> Handle(GetRepliesRequest request, CancellationToken cancellationToken)
    {
        var replies =  _tweetRepository
            .Get(tweet => tweet.ParentTweetId == request.TweetId);

        return new GetRepliesResponse
        {
            Replies = replies.ToList()
        };
    }
}