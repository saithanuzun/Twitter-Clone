using AutoMapper;
using MediatR;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Queries.Tweet.GetTweet;

public class GetTweetHandler : IRequestHandler<GetTweetRequest,GetTweetResponse>
{
    private readonly ITweetRepository _tweetRepository;
    private readonly IUserRepository _userRepository;
    private readonly ITweetLikeRepository _tweetLikeRepository;
    private readonly IMapper _mapper;

    public GetTweetHandler(ITweetRepository tweetRepository, IMapper mapper, IUserRepository userRepository, ITweetLikeRepository tweetLikeRepository)
    {
        _tweetRepository = tweetRepository;
        _mapper = mapper;
        _userRepository = userRepository;
        _tweetLikeRepository = tweetLikeRepository;
    }

    public async Task<GetTweetResponse> Handle(GetTweetRequest request, CancellationToken cancellationToken)
    {
        var tweet = await _tweetRepository.GetByIdAsync(request.Id);
        var user = await _userRepository.GetByIdAsync(tweet.UserId,default,i=>i.Profile);
        var likedByUsersCount = _tweetLikeRepository
            .Get(i => i.TweetId == tweet.Id)
            .Select(i => i.UserId)
            .ToList()
            .Count();
        var repliesCount =  _tweetRepository
            .Get(tweet => tweet.ParentTweetId == tweet.Id)
            .ToList().Count;

        return new GetTweetResponse()
        {
            CreatedDate = tweet.CreatedDate,
            Id = tweet.Id,
            Content = tweet.Content, 
            MediaUrl = tweet.MediaUrl, 
    
            IsDeleted = tweet.IsDeleted,
            DeletedDate = tweet.DeletedDate, 
    
            ParentTweetId = tweet.ParentTweetId, 

            UserId = tweet.UserId, 
            IsRetweet = tweet.IsRetweet,
            RetweetParentId = tweet.RetweetParentId, 

            RetweetCount = 0, // Todo: implement 
            LikeCount = likedByUsersCount,
            RepliesCount = repliesCount,

            UserUsername = user.Username, 
            UserProfilePic = user.Profile.ImageUrl , 
            UserDisplayName = user.Profile.DisplayName, 
        };
    }
}