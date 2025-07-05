using Twitter.Frontend.BlazorApp.Infrastructure.Models.Dtos;
using Twitter.Frontend.BlazorApp.Infrastructure.Models.Dvos;
using Twitter.Frontend.BlazorApp.Pagination;

namespace Twitter.Frontend.BlazorApp.Infrastructure.Services.Interfaces;

public interface ITweetService
{
    Task<List<TweetDvo>> GetTweets();
    Task<TweetDvo> GetTweet(Guid tweetId);
    Task<PagedViewModel<TweetDvo>> GetMainPageTweets(int page, int pageSize);
    Task<PagedViewModel<TweetDvo>> GetProfilePageEntries(int page, int pageSize, string userName = null);
    Task<PagedViewModel<TweetDvo>> GetEntryComments(Guid entryId, int page, int pageSize);
    Task<Guid> CreateEntry(CreateTweetDto command);
    //Task<List<SearchEntryDvo>> SearchBySubject(string searchText);

}