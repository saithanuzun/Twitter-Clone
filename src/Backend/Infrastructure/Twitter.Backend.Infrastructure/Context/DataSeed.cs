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
        var profileFaker = new Faker<UserProfile>()
            .RuleFor(i => i.Id, i => Guid.NewGuid())
            .RuleFor(i => i.CreatedDate,
                i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
            .RuleFor(i => i.FirstName, i => i.Person.FirstName)
            .RuleFor(i => i.LastName, i => i.Person.LastName)
            .RuleFor(i => i.DisplayName, i => $"{i.Person.FullName.Trim()}{i.Random.Int(1950,2005)}")
            .RuleFor(i => i.Location, i => i.Address.City())
            .RuleFor(i => i.Bio, i => i.Lorem.Sentence(5))
            .RuleFor(i => i.ImageUrl, i => i.Image.PicsumUrl());

        var result = new Faker<User>("en")
            .RuleFor(i => i.Id, i => Guid.NewGuid())
            .RuleFor(i => i.CreatedDate,
                i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
            .RuleFor(i=>i.Profile,i=>profileFaker.Generate())
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
        var tweetGuids = Enumerable.Range(0, 250).Select(i => Guid.NewGuid()).ToList();
        var counter = 0;

        var tweets = new Faker<Tweet>("en")
            .RuleFor(i => i.Id, i => tweetGuids[counter++])
            .RuleFor(t => t.MediaUrl, (k) =>
            {
                return k.Random.Int() % 2 == 0 && k.Random.Bool() 
                    ? k.Image.PlaceImgUrl() 
                    : null;
            })
            .RuleFor(i => i.CreatedDate,
                i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
            .RuleFor(i => i.Content, i => i.Lorem.Paragraph(2))
            .RuleFor(i => i.UserId, i => i.PickRandom(userIds))
            .Generate(150);

        await context.Tweets.AddRangeAsync(tweets);
        
        //replies
        
        var replies = new Faker<Tweet>("en")
            .RuleFor(i => i.Id, i => tweetGuids[counter++])
            .RuleFor(i => i.CreatedDate,
                i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
            .RuleFor(i => i.Content, i => i.Lorem.Paragraph(2))
            .RuleFor(i => i.UserId, i => i.PickRandom(userIds))
            .RuleFor(i=>i.ParentTweetId,i=>i.PickRandom(tweetGuids.GetRange(0,150)))
            .Generate(50);
        
        await context.Tweets.AddRangeAsync(replies);

        
         
        //retweets
        var retweets = new Faker<Tweet>("en")
            .RuleFor(i => i.Id, i => tweetGuids[counter++])
            .RuleFor(i => i.CreatedDate,
                i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
            .RuleFor(i=>i.IsRetweet,i=>true)
            .RuleFor(i => i.Content, i => i.Lorem.Paragraph(2))
            .RuleFor(i => i.UserId, i => i.PickRandom(userIds))
            .RuleFor(i=>i.RetweetParentId,i=>i.PickRandom(tweetGuids.GetRange(0,150)))
            .Generate(50);
        
        

        await context.Tweets.AddRangeAsync(retweets);
        
        //hashtags
        var hashtagsGuids = Enumerable.Range(0, 10).Select(i => Guid.NewGuid()).ToList();
        var counter4 = 0;
        var hashtags = new Faker<Hashtag>("en")
            .RuleFor(i => i.Id, i => hashtagsGuids[counter4++])
            .RuleFor(i => i.Tag, i => "#" + i.Lorem.Word())
            .Generate(10);

        await context.Hashtags.AddRangeAsync(hashtags);
        
        var TweetHashtagsGuids = Enumerable.Range(0, 10).Select(i => Guid.NewGuid()).ToList();
        var counter5 = 0;
        
        var tweetHashtags = new Faker<TweetHashtag>("en")
            .RuleFor(i=>i.Id,i=>TweetHashtagsGuids[counter5++])
            .RuleFor(i => i.HashtagId, i => i.PickRandom(hashtagsGuids))
            .RuleFor(i => i.TweetId, i => i.PickRandom(tweetGuids))
            .Generate(10);

        await context.TweetHashtags.AddRangeAsync(tweetHashtags);
        
        
        //likes
        var TweetLikes = Enumerable.Range(0, 50).Select(i => Guid.NewGuid()).ToList();
        var counter6 = 0;
        var tweetLikes = new Faker<TweetLike>("en")
            .RuleFor(i=>i.Id,i=>TweetLikes[counter6++])
            .RuleFor(i => i.UserId, i => i.PickRandom(userIds))
            .RuleFor(i => i.TweetId, i => i.PickRandom(tweetGuids))
            .Generate(50);

        await context.TweetLikes.AddRangeAsync(tweetLikes);
        
        // For testing it allows users to follow themselves and follow the same user multiple times for taken 50 users.
        var userFollowId = Enumerable.Range(0, 1000).Select(i => Guid.NewGuid()).ToList();
        var newUserIds = userIds.Take(50).ToList();
        var counter7 = 0;
        var userFollows = new Faker<UserFollow>("en")
            .RuleFor(i=>i.Id,i=>userFollowId[counter7++])
            .RuleFor(i => i.FollowerId, i => i.PickRandom(newUserIds))
            .RuleFor(i => i.FollowingId, i => i.PickRandom(newUserIds))
            .Generate(1000);

        await context.UserFollows.AddRangeAsync(userFollows);
        
        
        await context.SaveChangesAsync();
    }
}

