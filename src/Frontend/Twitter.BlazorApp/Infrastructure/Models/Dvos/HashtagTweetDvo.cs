using System.Text.Json.Serialization;

namespace Twitter.BlazorApp.Infrastructure.Models.Dvos;

public class HashtagTweetDvo 
{
    [JsonPropertyName("hashtagId")]
    public int? HashtagId { get; set; }
    
    [JsonPropertyName("tag")]
    public string Tag { get; set; }
    
    [JsonPropertyName("hashtagTweetsIds")]
    public List<string> HashtagTweetsIds { get; set; }
    
    [JsonPropertyName("tweetsCount")]
    public int TweetsCount { get; set; }
}