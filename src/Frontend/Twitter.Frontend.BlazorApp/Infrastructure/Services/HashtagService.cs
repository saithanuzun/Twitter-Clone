using System.Text.Json;
using Twitter.Frontend.BlazorApp.Infrastructure.Models.Dvos;
using Twitter.Frontend.BlazorApp.Infrastructure.Services.Interfaces;

namespace Twitter.Frontend.BlazorApp.Infrastructure.Services;

public class HashtagService : IHashtagService
{
    public HttpClient _Client { get; set; }

    public HashtagService(HttpClient client)
    {
        _Client = client;
    }


    public async Task<HashtagsDvo> GetHashtags()
    {
        Console.WriteLine("Starting GetHashtags...");

        var response = await _Client.GetAsync($"/api/hashtag/get-all");
        Console.WriteLine($"Response received. Status code: {response.StatusCode}");

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Raw JSON: {json}");

        var dvo = JsonSerializer.Deserialize<HashtagsDvo>(json);

        if (dvo == null)
        {
            Console.WriteLine("Deserialization failed: dvo is null.");
        }
        else
        {
            Console.WriteLine($"Deserialization succeeded. Hashtags count: {dvo.Hashtags.Count().ToString()}");
        }

        return dvo;
    }
    
}