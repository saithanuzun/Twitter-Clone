using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twitter.Backend.Domain.Entities;

namespace Twitter.Backend.Infrastructure.EntityConfigurations;

public class TweetHashtagConfiguration : BaseEntityConfiguration<TweetHashtag>
{
    public override void Configure(EntityTypeBuilder<TweetHashtag> builder)
    {
        base.Configure(builder);

        builder.HasOne(i => i.Tweet)
            .WithMany(i => i.TweetHashtags)
            .HasForeignKey(i => i.TweetId);

        builder.HasOne(i => i.Hashtag)
            .WithMany(i => i.TweetHashtags)
            .HasForeignKey(i => i.HashtagId);

    }
}