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

    public Task<PagedViewModel<TweetDvo>> GetProfilePageEntries(int page, int pageSize, string userName = null)
    {
        
    }

    public Task<PagedViewModel<TweetDvo>> GetEntryComments(Guid entryId, int page, int pageSize)
    {
        
    }

    public Task<Guid> CreateEntry(CreateTweetDto command)
    {
        throw new NotImplementedException();
        
    }
}
