namespace Twitter.Backend.Domain.Entities;

public class Tweet : BaseEntity
{
    public string Content { get; set; }
    
    //soft delete
    public bool IsDeleted { get; set; }
    public DateTime DeletedDate { get; set; }
    
    // Self-reference: Parent Tweet (if this is a reply)
    public Guid? ParentTweetId { get; set; }
    public Tweet? ParentTweet { get; set; }

    // Self-reference: Replies to this tweet
    public ICollection<Tweet>? Replies { get; set; }
    
    // Owner
    public Guid UserId { get; set; }
    public User User { get; set; }

    public bool IsRetweet { get; set; }
    
    // Retweets
    public Guid? RetweetParentId { get; set; }
    public Tweet? RetweetParent { get; set; }

    public ICollection<Tweet> Retweets { get; set; } 
    

    public ICollection<TweetLike>? TweetLikes { get; set; }

    public ICollection<TweetHashtag> TweetHashtags { get; set; }
}