using System.Text.Json.Serialization;

namespace Twitter.BlazorApp.Infrastructure.Models.Dvos;

public class HashtagsDvo
{
    [JsonPropertyName("hashtags")]
    public List<string> Hashtags { get; set; }

}