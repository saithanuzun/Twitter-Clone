namespace Twitter.Backend.Domain.Entities;

public class Tweet : BaseEntity
{
    public string Content { get; private set; }
    public string? MediaUrl { get; private set; }
    

    // Self reference Parent Tweet (Reply)
    public Guid? ParentTweetId { get; private set; }
    public virtual Tweet? ParentTweet { get; private set; }

    // Self reference: Replies to this tweet
    public virtual ICollection<Tweet> Replies { get; private set; } = new List<Tweet>();

    // Owner
    public Guid UserId { get; private set; }
    public virtual User User { get; private set; }

    public bool IsRetweet { get; private set; }

    // Retweets
    public Guid? RetweetParentId { get; private set; }
    public virtual Tweet? RetweetParent { get; private set; }

    public virtual ICollection<Tweet> Retweets { get; private set; } = new List<Tweet>();

    public virtual ICollection<TweetLike> TweetLikes { get; private set; } = new List<TweetLike>();

    public virtual ICollection<TweetHashtag> TweetHashtags { get; private set; } = new List<TweetHashtag>();
    
    public int RetweetCount => Retweets.Count;
    public int ReplyCount => Replies.Count;
    public int LikeCount => TweetLikes.Count;


    protected Tweet() { }

    public static Tweet Create(Guid userId, string content, string? mediaUrl = null)
    {
        if (string.IsNullOrWhiteSpace(content)) throw new ArgumentException("Tweet content cannot be empty", nameof(content));
        
        if (content.Length > 280)
            throw new ArgumentException("Tweet exceeds maximum length", nameof(content));


        return new Tweet
        {
            UserId = userId,
            Content = content,
            MediaUrl = mediaUrl,
            IsRetweet = false,
        };
    }

    public static Tweet CreateReply(Guid userId, Guid parentTweetId, string content, string? mediaUrl = null)
    {
        var tweet = Create(userId, content, mediaUrl);
        tweet.ParentTweetId = parentTweetId;
        return tweet;
    }

    public static Tweet CreateRetweet(Guid userId, Guid originalTweetId)
    {
        return new Tweet
        {
            UserId = userId,
            RetweetParentId = originalTweetId,
            IsRetweet = true,
            Content = string.Empty, 
        };
    }
    
    
    
}