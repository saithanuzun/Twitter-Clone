namespace Twitter.Backend.Application.Features.Queries.Tweet.GetTweetLikes;

public class GetTweetLikesResponse
{
    public Guid TweetId { get; set; }
    public List<Guid> UserIds { get; set; }
    public int LikesCount { get; set; }
}