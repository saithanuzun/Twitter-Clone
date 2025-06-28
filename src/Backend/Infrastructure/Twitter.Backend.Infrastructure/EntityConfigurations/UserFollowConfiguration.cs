using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twitter.Backend.Domain.Entities;

namespace Twitter.Backend.Infrastructure.EntityConfigurations;

public class UserFollowConfiguration : BaseEntityConfiguration<UserFollow>      
{
    public override void Configure(EntityTypeBuilder<UserFollow> builder)
    {
        base.Configure(builder);        
    }
}