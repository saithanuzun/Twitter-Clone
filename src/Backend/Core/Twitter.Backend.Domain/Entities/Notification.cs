namespace Twitter.Backend.Domain.Entities;

public class Notification : BaseEntity
{
    // Owner
    public Guid UserId { get; private set; }
    public virtual User User { get; private set; }

    // Notification details
    public Guid? TweetId { get; set; }
    public virtual Tweet? Tweet { get; set; }

    public Guid? FromUserId { get; private set; } // The user who triggered the notification
    public virtual User? FromUser { get; private set; }

    public NotificationType Type { get; private set; }
    public bool IsRead { get; private set; }

    private Notification() { } // For EF Core

    public Notification(Guid userId, NotificationType type, Guid? tweetId = null, Guid? fromUserId = null) 
    {
        UserId = userId;
        Type = type;
        TweetId = tweetId;
        FromUserId = fromUserId;
        IsRead = false;
    }

    public void MarkAsRead()
    {
        IsRead = true;
    }
}

public enum NotificationType
{
    Tweet,
    Retweet,
    Follow
}