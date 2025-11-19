using MediatR;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Queries.User.GetUserLikes;

public class GetUserLikesHandler : IRequestHandler<GetUserLikesRequest,GetUserLikesResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly ITweetRepository _tweetRepository;
    private readonly ITweetLikeRepository _tweetLikeRepository;


    public GetUserLikesHandler(IUserRepository userRepository, ITweetRepository tweetRepository)
    {
        _userRepository = userRepository;
        _tweetRepository = tweetRepository;
    }

    public async Task<GetUserLikesResponse> Handle(GetUserLikesRequest request, CancellationToken cancellationToken)
    {
        var tweets = _tweetLikeRepository
            .Get(i => i.User != null && i.User.Username == request.username, default, i => i.User)
            .Select(i => i.TweetId)
            .ToList();

        return new GetUserLikesResponse
        {
            UserId = request.UserId,
            Username = request.username,
            TweetIds = tweets
        };
    }

}