using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twitter.Backend.Domain.Entities;

namespace Twitter.Backend.Infrastructure.EntityConfigurations;

public class UserProfileConfiguration : BaseEntityConfiguration<UserProfile>
{
    public override void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        base.Configure(builder);    
    }
}