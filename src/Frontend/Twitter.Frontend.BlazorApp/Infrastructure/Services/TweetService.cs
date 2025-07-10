using Twitter.Frontend.BlazorApp.Infrastructure.Models.Dtos;
using Twitter.Frontend.BlazorApp.Infrastructure.Models.Dvos;
using Twitter.Frontend.BlazorApp.Infrastructure.Services.Interfaces;
using Twitter.Frontend.BlazorApp.Layout;
using Twitter.Frontend.BlazorApp.Pagination;

namespace Twitter.Frontend.BlazorApp.Infrastructure.Services;

public class TweetService : ITweetService
{
    public Task<List<TweetDvo>> GetTweets()
    {
        throw new NotImplementedException();
    }

    public Task<TweetDvo> GetTweet(Guid tweetId)
    {
        throw new NotImplementedException();
    }

    public Task<PagedViewModel<TweetDvo>> GetMainPageTweets(int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<PagedViewModel<TweetDvo>> GetUserTweets(int page, int pageSize, string userName = null)
    {
        throw new NotImplementedException();
    }

    public Task<PagedViewModel<TweetDvo>> GetTweetReplies(Guid entryId, int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> CreateTweet(CreateTweetDto command)
    {
        throw new NotImplementedException();
    }

    public Task<List<Guid>> GetHashtagTweets(string tag)
    {
        throw new NotImplementedException();
    }
}
