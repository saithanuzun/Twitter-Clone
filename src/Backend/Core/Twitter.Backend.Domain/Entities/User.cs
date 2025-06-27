namespace Twitter.Backend.Domain.Entities;

public class User : BaseEntity
{

    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    
    //one to one
    public UserProfile Profile { get; set; }
    
    //one to many tweets
    public virtual ICollection<Tweet> Tweets { get; set; }
    
    // Followers and Following ef lazy loading 
    public virtual ICollection<UserFollow> Followers { get; set; } 
    public virtual ICollection<UserFollow> Following { get; set; } 
    
    
    //many to many
    public virtual ICollection<TweetLike> TweetLikes { get; set; }
}