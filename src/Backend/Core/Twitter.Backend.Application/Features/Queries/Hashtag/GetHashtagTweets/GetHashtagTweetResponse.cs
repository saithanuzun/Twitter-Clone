namespace Twitter.Backend.Application.Features.Queries.Hashtag.GetHashtagTweets;

public class GetHashtagTweetResponse
{
    public Guid HashtagId { get; set; }
    public List<Guid> HashtagTweetsIds { get; set; }
}