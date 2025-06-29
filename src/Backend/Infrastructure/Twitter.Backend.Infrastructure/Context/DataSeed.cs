using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Twitter.Backend.Application.Encryptor;
using Twitter.Backend.Domain.Entities;

namespace Twitter.Backend.Infrastructure.Context;

public class DataSeed
{
    private List<User> GetUsers()
    {
        var result = new Faker<User>("en")
            .RuleFor(i => i.Id, i => Guid.NewGuid())
            .RuleFor(i => i.CreatedDate,
                i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))

            .RuleFor(i => i.Profile.FirstName, i => i.Person.FirstName)
            .RuleFor(i => i.Profile.LastName, i => i.Person.LastName)
            .RuleFor(i => i.Profile.Location, i => i.Address.City())
            .RuleFor(i => i.Profile.Bio, i => i.Lorem.Sentence(5))
            .RuleFor(i => i.Profile.ImageUrl, i => i.Image.PicsumUrl())


            .RuleFor(i => i.Email, i => i.Internet.Email())
            .RuleFor(i => i.Username, i => i.Internet.UserName())
            .RuleFor(i => i.PasswordHash, i => PasswordEncryptor.Encrypt(i.Internet.Password()))
            .Generate(500);

        return result;
    }

    public async Task SeedAsync(IConfiguration configuration)
    {
        var dbContextBuilder = new DbContextOptionsBuilder();
        dbContextBuilder.UseNpgsql(configuration.GetConnectionString("PostgreSql"));

        var context = new TwitterContext(dbContextBuilder.Options);

        if (context.Tweets.Any())
        {
            await Task.CompletedTask;
            return;
        }

        //users
        var users = GetUsers();
        var userIds = users.Select(i => i.Id);

        await context.Users.AddRangeAsync(users);

        //tweets
        var tweetGuids = Enumerable.Range(0, 150).Select(i => Guid.NewGuid()).ToList();
        var counter = 0;

        var tweets = new Faker<Tweet>("en")
            .RuleFor(i => i.Id, i => tweetGuids[counter++])
            .RuleFor(i => i.CreatedDate,
                i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
            .RuleFor(i => i.Content, i => i.Lorem.Paragraph(2))
            .RuleFor(i => i.UserId, i => i.PickRandom(userIds))
            .Generate(150);

        await context.Tweets.AddRangeAsync(tweets);
        
        //replies
        var repliesGuids = Enumerable.Range(0, 50).Select(i => Guid.NewGuid()).ToList(); 
         counter = 0;
        
        var replies = new Faker<Tweet>("en")
            .RuleFor(i => i.Id, i => repliesGuids[counter++])
            .RuleFor(i => i.CreatedDate,
                i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
            .RuleFor(i => i.Content, i => i.Lorem.Paragraph(2))
            .RuleFor(i => i.UserId, i => i.PickRandom(userIds))
            .RuleFor(i=>i.ParentTweetId,i=>i.PickRandom(tweetGuids))
            .Generate(50);
        
        var retweetGuids = Enumerable.Range(0, 50).Select(i => Guid.NewGuid()).ToList(); 
         counter = 0;
         
        //retweets
        var retweets = new Faker<Tweet>("en")
            .RuleFor(i => i.Id, i => repliesGuids[counter++])
            .RuleFor(i => i.CreatedDate,
                i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
            .RuleFor(i => i.Content, i => i.Lorem.Paragraph(2))
            .RuleFor(i => i.UserId, i => i.PickRandom(userIds))
            .RuleFor(i=>i.RetweetParentId,i=>i.PickRandom(retweetGuids))
            .Generate(50);
        
        

        await context.Tweets.AddRangeAsync(tweets);
        await context.Tweets.AddRangeAsync(retweets);
        await context.Tweets.AddRangeAsync(replies);
        
        //hashtags
        var hashtagsGuids = Enumerable.Range(0, 10).Select(i => Guid.NewGuid()).ToList(); 
         counter = 0;

        var hashtags = new Faker<Hashtag>("en")
            .RuleFor(i => i.Id, i => hashtagsGuids[counter++])
            .RuleFor(i => i.Tag, i => "#" + i.Lorem.Word())
            .Generate(10);

        await context.Hashtags.AddRangeAsync(hashtags);
        
        var tweetHashtags = new Faker<TweetHashtag>("en")
            .RuleFor(i=>i.Id,i=>Guid.NewGuid())
            .RuleFor(i => i.HashtagId, i => i.PickRandom(hashtagsGuids))
            .RuleFor(i => i.TweetId, i => i.PickRandom(tweetGuids))
            .Generate(10);

        await context.TweetHashtags.AddRangeAsync(tweetHashtags);
        
        
        //likes
        var tweetLikes = new Faker<TweetLike>("en")
            .RuleFor(i=>i.Id,i=>Guid.NewGuid())
            .RuleFor(i => i.UserId, i => i.PickRandom(userIds))
            .RuleFor(i => i.TweetId, i => i.PickRandom(tweetGuids))
            .Generate(50);

        await context.TweetLikes.AddRangeAsync(tweetLikes);
        
            


        await context.SaveChangesAsync();
    }
}

