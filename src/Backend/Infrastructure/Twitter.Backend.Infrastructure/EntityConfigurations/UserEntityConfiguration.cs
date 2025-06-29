using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twitter.Backend.Domain.Entities;

namespace Twitter.Backend.Infrastructure.EntityConfigurations;

public class UserEntityConfiguration: BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        builder.ToTable("user");

        builder.HasOne(i => i.Profile)
            .WithOne(i => i.User)
            .HasForeignKey<UserProfile>(i => i.UserId);

        
        
    }
}