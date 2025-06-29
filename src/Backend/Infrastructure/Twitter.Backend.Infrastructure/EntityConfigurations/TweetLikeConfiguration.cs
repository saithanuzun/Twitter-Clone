using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twitter.Backend.Domain.Entities;

namespace Twitter.Backend.Infrastructure.EntityConfigurations;

public class TweetLikeConfiguration : BaseEntityConfiguration<TweetLike>
{
    public override void Configure(EntityTypeBuilder<TweetLike> builder)
    {
        base.Configure(builder);
        
        builder.HasOne(i => i.Tweet)
            .WithMany(i => i.TweetLikes)
            .HasForeignKey(i => i.TweetId);

        builder.HasOne(i => i.User)
            .WithMany(i => i.TweetLikes)
            .HasForeignKey(i => i.UserId);


    }
}