using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twitter.Backend.Domain.Entities;

namespace Twitter.Backend.Infrastructure.EntityConfigurations;

public class TweetLikeConfiguration : BaseEntityConfiguration<TweetLike>
{
    public override void Configure(EntityTypeBuilder<TweetLike> builder)
    {
        base.Configure(builder);
    }
}