using MediatR;
using Twitter.Backend.Application.Extensions;
using Twitter.Backend.Application.Pagination;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Queries.Tweet.GetMainPageTweets;

public class
    GetMainPageTweetsHandler : IRequestHandler<GetMainPageTweetsRequest, PaginationResponse<GetMainPageTweetsResponse>>
{
    private readonly ITweetRepository _tweetRepository;
    private readonly IUserRepository _userRepository;
    private readonly ITweetLikeRepository _tweetLikeRepository;
    

    public GetMainPageTweetsHandler(ITweetRepository tweetRepository, ITweetLikeRepository tweetLikeRepository, IUserRepository userRepository)
    {
        _tweetRepository = tweetRepository;
        _tweetLikeRepository = tweetLikeRepository;
        _userRepository = userRepository;
    }
    
    // TODO: Implement the main page tweet functionality.

    public async Task<PaginationResponse<GetMainPageTweetsResponse>> Handle(GetMainPageTweetsRequest request, CancellationToken cancellationToken)
    {
        var query = _tweetRepository.AsQueryable();

        var list = query.Select(i => new GetMainPageTweetsResponse
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
        });

        return  list.GetPaged(request.PageSize, request.Page);
    }

}


   