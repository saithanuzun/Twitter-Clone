using Twitter.Backend.Application.Features.Queries.Tweet.GetTweet;

namespace Twitter.Backend.Application.Features.Queries.User.GetUserTweets;

public class GetUserTweetsResponse
{
    public Guid? UserId { get; set; }
    public string? Username { get; set; }
    public List<Guid> TweetIds{ get; set; }
}