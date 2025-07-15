using Twitter.Frontend.BlazorApp.Infrastructure.Models.Dtos;
using Twitter.Frontend.BlazorApp.Infrastructure.Models.Dvos;
using Twitter.Frontend.BlazorApp.Pagination;

namespace Twitter.Frontend.BlazorApp.Infrastructure.Services.Interfaces;

public interface ITweetService
{
    Task<List<TweetDvo>> GetTweets();
    Task<TweetDvo> GetTweet(string tweetId);
    Task<PagedViewModel<TweetDvo>> GetMainPageTweets(int page, int pageSize);
    Task<PagedViewModel<TweetDvo>> GetUserTweets(int page, int pageSize, string userName = null);
    Task<PagedViewModel<TweetDvo>> GetTweetReplies(Guid entryId, int page, int pageSize);
    Task<Guid> CreateTweet(CreateTweetDto command);
    
    Task<List<Guid>> GetHashtagTweets(string tag);

    //Task<List<SearchEntryDvo>> SearchBySubject(string searchText);

}