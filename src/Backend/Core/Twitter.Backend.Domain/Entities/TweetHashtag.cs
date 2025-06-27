namespace Twitter.Backend.Domain.Entities;

public class TweetHashtag
{
    public Guid TweetId { get; set; }
    public Tweet Tweet { get; set; }

    public Guid HashtagId { get; set; }
    public Hashtag Hashtag { get; set; }
}
