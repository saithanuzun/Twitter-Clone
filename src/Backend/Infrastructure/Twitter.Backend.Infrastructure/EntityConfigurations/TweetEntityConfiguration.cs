using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twitter.Backend.Domain.Entities;

namespace Twitter.Backend.Infrastructure.EntityConfigurations;

public class TweetEntityConfiguration : BaseEntityConfiguration<Tweet>
{
    public override void Configure(EntityTypeBuilder<Tweet> builder)
    {
        base.Configure(builder);
        
    }
}