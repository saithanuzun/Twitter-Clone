using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twitter.Backend.Domain.Entities;

namespace Twitter.Backend.Infrastructure.EntityConfigurations;

public class TweetEntityConfiguration : BaseEntityConfiguration<Tweet>
{
    public override void Configure(EntityTypeBuilder<Tweet> builder)
    {
        base.Configure(builder);
        
        builder.HasOne(i => i.ParentTweet)
            .WithMany(i => i.Replies)
            .HasForeignKey(i => i.ParentTweetId);

        builder.HasOne(i => i.RetweetParent)
            .WithMany(i => i.Retweets)
            .HasForeignKey(i => i.RetweetParentId);

        builder.HasOne(i => i.User)
            .WithMany(i => i.Tweets)
            .HasForeignKey(i => i.UserId);

    }
}