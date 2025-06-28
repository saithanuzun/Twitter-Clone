using Microsoft.EntityFrameworkCore;
using Twitter.Backend.Domain.Entities;

namespace Twitter.Backend.Infrastructure.Context;

public class TwitterContext : DbContext
{
    public TwitterContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Tweet> Tweets { get; set; }
    public DbSet<Hashtag> Hashtags { get; set; }

    public DbSet<TweetLike> TweetLikes { get; set; }
    public DbSet<TweetHashtag> TweetHashtags { get; set; }
    public DbSet<UserFollow> UserFollows { get; set; }
    
    private void PrepareAddedEntity(IEnumerable<BaseEntity> entities)
    {
        foreach (var entity in entities)
            if (entity.CreatedDate == DateTime.MinValue)
            {
                entity.CreatedDate = DateTime.Now;
            }
    }
    
    
    
}