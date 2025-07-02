using MediatR;

namespace Twitter.Backend.Application.Features.Queries.Tweet.GetTweetLikes;

public class GetTweetLikesRequest : IRequest<GetTweetLikesResponse>
{
    public Guid TweetId { get; set; }
    
}