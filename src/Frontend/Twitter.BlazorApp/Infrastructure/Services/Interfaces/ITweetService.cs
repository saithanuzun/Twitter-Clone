using Twitter.BlazorApp.Infrastructure.Models.Dtos;
using Twitter.BlazorApp.Infrastructure.Models.Dvos;
using Twitter.BlazorApp.Pagination;

namespace Twitter.BlazorApp.Infrastructure.Services.Interfaces;

public interface ITweetService
{
    Task<List<TweetDvo>> GetTweets();
    Task<TweetDvo> GetTweet(string tweetId);
    Task<PagedViewModel<TweetDvo>> GetMainPageTweets(int page, int pageSize);
    Task<PagedViewModel<TweetDvo>> GetUserTweets(int page, int pageSize, string userName = null);
    Task<List<TweetDvo>> GetTweetReplies(string tweetId, int page, int pageSize);
    
    Task<TweetLikeDvo> GetTweetLikes(string tweetId);

    Task<Guid> CreateTweet(CreateTweetDto command);
    
    Task<List<Guid>> GetHashtagTweets(string tag);

    //Task<List<SearchEntryDvo>> SearchBySubject(string searchText);

}