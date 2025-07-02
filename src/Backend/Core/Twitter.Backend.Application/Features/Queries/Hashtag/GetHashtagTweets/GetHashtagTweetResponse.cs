namespace Twitter.Backend.Application.Features.Queries.Hashtag.GetHashtagTweets;

public class GetHashtagTweetResponse
{
    public Guid HashtagId { get; set; }
    public List<Domain.Entities.Tweet> HashtagTweets { get; set; }
}