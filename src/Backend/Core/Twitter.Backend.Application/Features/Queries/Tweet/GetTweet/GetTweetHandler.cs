using AutoMapper;
using MediatR;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Queries.Tweet.GetTweet;

public class GetTweetHandler : IRequestHandler<GetTweetRequest, GetTweetResponse>
{
    private readonly ITweetRepository _tweetRepository;
    private readonly IUserRepository _userRepository;
    private readonly ITweetLikeRepository _tweetLikeRepository;
    private readonly ITweetHashTagRepository _hashtagRepository;
    private readonly IMapper _mapper;

    public GetTweetHandler(ITweetRepository tweetRepository, IMapper mapper, IUserRepository userRepository,
        ITweetLikeRepository tweetLikeRepository, ITweetHashTagRepository hashtagRepository)
    {
        _tweetRepository = tweetRepository;
        _mapper = mapper;
        _userRepository = userRepository;
        _tweetLikeRepository = tweetLikeRepository;
        _hashtagRepository = hashtagRepository;
    }

    public async Task<GetTweetResponse> Handle(GetTweetRequest request, CancellationToken cancellationToken)
    {
        var query = _tweetRepository.AsQueryable();


        var result = query
            .Where(i => i.Id == request.Id)
            .Select(i => new GetTweetResponse()
            {
                Id = i.Id,
                Content = i.Content,
                MediaUrl = i.MediaUrl,
                CreatedDate = i.CreatedDate,
                IsDeleted = i.IsDeleted,
                DeletedDate = i.DeletedDate,
                ParentTweetId = i.ParentTweetId,
                UserId = i.UserId,
                IsRetweet = i.IsRetweet,
                RetweetParentId = i.RetweetParentId,
                UserUsername = i.User.Username,
                UserDisplayName = i.User.Profile.DisplayName,
                UserProfilePic = i.User.Profile.ImageUrl,
                LikeCount = i.TweetLikes.Count,
                RepliesCount = i.Replies.Count,
                RetweetCount = i.Retweets.Count,
                Hashtags = i.TweetHashtags.Select(i => i.Hashtag.Tag).ToList()
            });

        return result.FirstOrDefault();
    }
}