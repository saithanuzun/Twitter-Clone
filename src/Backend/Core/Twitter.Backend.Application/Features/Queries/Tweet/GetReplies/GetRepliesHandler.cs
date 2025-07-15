using AutoMapper;
using MediatR;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Queries.Tweet.GetReplies;

public class GetRepliesHandler : IRequestHandler<GetRepliesRequest,List<GetRepliesResponse>>
{
    private ITweetRepository _tweetRepository;
    private IUserRepository _userRepository;
    private ITweetLikeRepository _tweetLikeRepository;
    
    private IMapper _mapper;

    public GetRepliesHandler(IMapper mapper, ITweetRepository tweetRepository, IUserRepository userRepository, ITweetLikeRepository tweetLikeRepository)
    {
        _mapper = mapper;
        _tweetRepository = tweetRepository;
        _userRepository = userRepository;
        _tweetLikeRepository = tweetLikeRepository;
    }

    public async Task<List<GetRepliesResponse>> Handle(GetRepliesRequest request, CancellationToken cancellationToken)
    {
        var result = new List<GetRepliesResponse>();
        
        
        var replies =  _tweetRepository
            .Get(tweet => tweet.ParentTweetId == request.TweetId)
            .Select(i=>i.Id)
            .ToList();

        foreach (var reply in replies)
        {
            var tweet = await _tweetRepository.GetByIdAsync(reply);
            var user = await _userRepository.GetByIdAsync(tweet.UserId,default,i=>i.Profile);
            var likedByUsersCount = _tweetLikeRepository
                .Get(i => i.TweetId == tweet.Id)
                .Select(i => i.UserId)
                .ToList()
                .Count();
            var repliesCount =  _tweetRepository
                .Get(tweet => tweet.ParentTweetId == tweet.Id)
                .ToList().Count;

            var item = new GetRepliesResponse()
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
            result.Add(item);
        }
        
        return result;
    }
}