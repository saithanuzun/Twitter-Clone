namespace Twitter.Backend.Domain.Entities;

public class Hashtag : BaseEntity
{
    public string Tag { get; set; }

    public ICollection<TweetHashtag> TweetHashtags { get; set; } 
}
