namespace Twitter.Backend.Domain.Entities;

public class TweetHashtag : BaseEntity
{
    public Guid TweetId { get; set; }
    public virtual Tweet Tweet { get; set; }

    public Guid HashtagId { get; set; }
    public virtual Hashtag Hashtag { get; set; }
}
