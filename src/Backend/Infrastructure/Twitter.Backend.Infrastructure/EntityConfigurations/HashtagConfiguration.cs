using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twitter.Backend.Domain.Entities;

namespace Twitter.Backend.Infrastructure.EntityConfigurations;

public class HashtagConfiguration : BaseEntityConfiguration<Hashtag>
{
    public override void Configure(EntityTypeBuilder<Hashtag> builder)
    {
        base.Configure(builder);
    }
}