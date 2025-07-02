using AutoMapper;
using MediatR;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Queries.Tweet.GetTweetLikes;

public class GetTweetLikeHandler : IRequestHandler<GetTweetLikesRequest,GetTweetLikesResponse>
{
    private ITweetLikeRepository _tweetLikeRepository;
    private IMapper _mapper;

    public GetTweetLikeHandler(ITweetLikeRepository tweetLikeRepository, IMapper mapper)
    {
        _tweetLikeRepository = tweetLikeRepository;
        _mapper = mapper;
    }

    public async Task<GetTweetLikesResponse> Handle(GetTweetLikesRequest request, CancellationToken cancellationToken)
    {
        var LikedByUsers = _tweetLikeRepository.Get(i => i.TweetId == request.TweetId).Select(i => i.UserId).ToList();

        return new GetTweetLikesResponse() {TweetId = request.TweetId,UserIds =LikedByUsers, LikesCount = LikedByUsers.Count};
    }
}