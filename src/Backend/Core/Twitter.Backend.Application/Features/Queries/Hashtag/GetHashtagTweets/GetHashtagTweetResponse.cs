namespace Twitter.Backend.Application.Features.Queries.Hashtag.GetHashtagTweets;

public class GetHashtagTweetResponse
{
    public Guid? HashtagId { get; set; }
    public string? Tag { get; set; }
    public List<Guid> HashtagTweetsIds { get; set; }
    public int TweetsCount { get; set; }
}