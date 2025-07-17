using System.Text.Json.Serialization;

namespace Twitter.BlazorApp.Infrastructure.Models.Dvos;

public class UserFollowingDvo
{
    [JsonPropertyName("userFollowingIds")]
    public List<string>? userFollowingIds { get; set; }
    
    [JsonPropertyName("usernames")]
    public List<string>? Usernames { get; set; }
    
    [JsonPropertyName("followingsCount")]
    public int followingsCount { get; set; }
    
    [JsonPropertyName("username")]
    public string? Username { get; set; }
    
    [JsonPropertyName("userId")]
    public Guid? UserId { get; set; }
}