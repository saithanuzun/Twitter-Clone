using System.Text.Json;
using Twitter.BlazorApp.Infrastructure.Models.Dtos;
using Twitter.BlazorApp.Infrastructure.Models.Dvos;
using Twitter.BlazorApp.Infrastructure.Services.Interfaces;
using Twitter.BlazorApp.Layout;
using Twitter.BlazorApp.Pagination;

namespace Twitter.BlazorApp.Infrastructure.Services;

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

    public async Task<PagedViewModel<TweetDvo>> GetMainPageTweets(int page, int pageSize)
    {
        Console.WriteLine("Starting getmainpage...");

        var response = await _client.GetAsync($"/api/tweet/feed?page={page}&pageSize={pageSize}");

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        Console.WriteLine(json);


        var dvo = JsonSerializer.Deserialize<PagedViewModel<TweetDvo>>(json);

        Console.WriteLine("done get main page..." + dvo.Results.Count);

        return dvo;
    }

    public Task<PagedViewModel<TweetDvo>> GetUserTweets(int page, int pageSize, string userName = null)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedViewModel<TweetDvo>> GetTweetReplies(string tweetId, int page, int pageSize)
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