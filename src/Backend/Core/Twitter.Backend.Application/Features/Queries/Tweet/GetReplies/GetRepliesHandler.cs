using AutoMapper;
using MediatR;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Queries.Tweet.GetReplies;

public class GetRepliesHandler : IRequestHandler<GetRepliesRequest, List<GetRepliesResponse>>
{
    private ITweetRepository _tweetRepository;
    private IUserRepository _userRepository;
    private ITweetLikeRepository _tweetLikeRepository;
    private ITweetHashTagRepository _hashTagRepository;

    private IMapper _mapper;

    public GetRepliesHandler(IMapper mapper, ITweetRepository tweetRepository, IUserRepository userRepository,
        ITweetLikeRepository tweetLikeRepository, ITweetHashTagRepository hashTagRepository)
    {
        _mapper = mapper;
        _tweetRepository = tweetRepository;
        _userRepository = userRepository;
        _tweetLikeRepository = tweetLikeRepository;
        _hashTagRepository = hashTagRepository;
    }

    public async Task<List<GetRepliesResponse>> Handle(GetRepliesRequest request, CancellationToken cancellationToken)
    {
        var query = _tweetRepository.AsQueryable();


        var result = query
            .Where(i => i.ParentTweetId == request.TweetId)
            .Select(i => new GetRepliesResponse()
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


        return result.ToList();
    }
}