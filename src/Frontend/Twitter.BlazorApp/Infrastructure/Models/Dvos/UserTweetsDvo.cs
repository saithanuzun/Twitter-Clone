using System.Text.Json.Serialization;

namespace Twitter.BlazorApp.Infrastructure.Models.Dvos;

public class UserTweetsDvo
{
    [JsonPropertyName("userId")]
    public string? UserId { get; set; }
    
    [JsonPropertyName("username")]
    public string Username { get; set; }
    
    [JsonPropertyName("tweetIds")]
    public List<string> TweetIds { get; set; }
}