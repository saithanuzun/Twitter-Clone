using Twitter.Backend.Application.Features.Queries.Tweet.GetTweet;

namespace Twitter.Backend.Application.Features.Queries.User.GetUserTweets;

public class GetUserTweetsResponse
{
    public Guid UserId { get; set; }
    public List<Domain.Entities.Tweet> Tweets{ get; set; }
}