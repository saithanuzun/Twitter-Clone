namespace Twitter.Backend.Domain.Entities;

public class TweetLike : BaseEntity
{
    public Guid TweetId { get; set; }
    public virtual Tweet Tweet { get; set; }
    
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}