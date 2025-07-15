using System.Text.Json;
using Twitter.Frontend.BlazorApp.Infrastructure.Models.Dtos;
using Twitter.Frontend.BlazorApp.Infrastructure.Models.Dvos;
using Twitter.Frontend.BlazorApp.Infrastructure.Services.Interfaces;
using Twitter.Frontend.BlazorApp.Layout;
using Twitter.Frontend.BlazorApp.Pagination;

namespace Twitter.Frontend.BlazorApp.Infrastructure.Services;

public class TweetService : ITweetService
{
    private HttpClient _client;

    public TweetService(HttpClient client)
    {
        _client = client;
    }

    public Task<List<TweetDvo>> GetTweets()
    {
        throw new NotImplementedException();
    }

    public async Task<TweetDvo> GetTweet(string tweetId)
    {
        var response = await _client.GetAsync($"/api/tweet/{tweetId}");
        response.EnsureSuccessStatusCode();
        
        var json = await response.Content.ReadAsStringAsync();
        
        var dvo = JsonSerializer.Deserialize<TweetDvo>(json);

        return dvo;
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
