using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Twitter.Backend.Domain.Entities;

namespace Twitter.Backend.Infrastructure.Context;

public class TwitterContext : DbContext
{
    public TwitterContext(DbContextOptions options) : base(options)
    {

    }
    
    public TwitterContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Tweet> Tweets { get; set; }
    public DbSet<Hashtag> Hashtags { get; set; }

    public DbSet<TweetLike> TweetLikes { get; set; }
    public DbSet<TweetHashtag> TweetHashtags { get; set; }
    public DbSet<UserFollow> UserFollows { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (!optionsBuilder.IsConfigured)
        {
            var connStr =
                "USER ID=postgres ; Password=password123;Server=localhost;Port=5432;Database=Twitter;Pooling=true";
            optionsBuilder.UseNpgsql(connStr, opt => { opt.EnableRetryOnFailure(); });
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        OnBeforeSave();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override int SaveChanges()
    {
        OnBeforeSave();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        OnBeforeSave();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = new())
    {
        OnBeforeSave();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void OnBeforeSave()
    {
        var addedEntities = ChangeTracker.Entries()
            .Where(i => i.State is EntityState.Added or EntityState.Modified)
            .Select(i => (BaseEntity)i.Entity);
        PrepareAddedEntity(addedEntities);
    }

    private void PrepareAddedEntity(IEnumerable<BaseEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.CreatedDate <= new DateTime(1900, 1, 1) || entity.CreatedDate.Kind != DateTimeKind.Utc)
                entity.CreatedDate = DateTime.UtcNow;

            entity.ModifiedDate = DateTime.UtcNow;
        }
    }

    
}