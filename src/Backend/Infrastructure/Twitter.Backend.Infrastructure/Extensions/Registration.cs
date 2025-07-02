using EksiSozluk.Api.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Twitter.Backend.Domain.Repositories;
using Twitter.Backend.Infrastructure.Context;

namespace Twitter.Backend.Infrastructure.Extensions;

public static class Registration
{
    public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connStr = configuration.GetConnectionString("PostgreSql");

        serviceCollection.AddDbContext<TwitterContext>(conf =>
        {
            conf.UseNpgsql(connStr, opt => { opt.EnableRetryOnFailure(); });
        });

        //var seedData = new DataSeed();
        //seedData.SeedAsync(configuration).GetAwaiter().GetResult();

        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<ITweetRepository, TweetRepository>();
        serviceCollection.AddScoped<IHashtagRepository, HashtagRepository>();
        serviceCollection.AddScoped<ITweetHashTagRepository, TweetHashtagRepository>();
        serviceCollection.AddScoped<ITweetLikeRepository, TweetLikeRepository>();
        serviceCollection.AddScoped<IUserFollowRepository, UserFollowRepository>();
        
        return serviceCollection;
    }
}