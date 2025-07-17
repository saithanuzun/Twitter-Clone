using System.Text.Json.Serialization;

namespace Twitter.BlazorApp.Infrastructure.Models.Dvos;

public class UserFollowersDvo
{
    [JsonPropertyName("followingUserIds")]
    public List<string>? FollowingUserIds { get; set; }

    [JsonPropertyName("usernames")]
    public List<string>? Usernames { get; set; }
    
    [JsonPropertyName("followersCount")]
    public int FollowersCount { get; set; }
    
    [JsonPropertyName("username")]
    public string? Username { get; set; }
    
    [JsonPropertyName("userId")]
    public Guid? UserId { get; set; }
}