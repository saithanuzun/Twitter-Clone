using System.Text.Json.Serialization;

namespace Twitter.BlazorApp.Infrastructure.Models.Dvos;

public class TweetDvo
{
    [JsonPropertyName("createdDate")]
    public DateTime CreatedDate { get; set; }
    
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    
    [JsonPropertyName("content")]
    public string Content { get; set; }
    
    
    [JsonPropertyName("mediaUrl")]
    public string MediaUrl { get; set; }
    
    [JsonPropertyName("isDeleted")]
    public bool IsDeleted { get; set; }
    
    [JsonPropertyName("deletedDate")]
    public DateTime DeletedDate { get; set; }
    
    [JsonPropertyName("parentTweetId")]
    public string? ParentTweetId { get; set; }
    
    [JsonPropertyName("userId")]
    public string UserId { get; set; }
    
    [JsonPropertyName("isRetweet")]
    public bool IsRetweet { get; set; }
    
    [JsonPropertyName("retweetParentId")]
    public string? RetweetParentId { get; set; }
    
    [JsonPropertyName("retweetCount")]
    public int RetweetCount { get; set; }
    
    [JsonPropertyName("likeCount")]
    public int LikeCount { get; set; }
    
    [JsonPropertyName("repliesCount")]
    public int RepliesCount { get; set; }
    
    [JsonPropertyName("userUsername")]
    public string UserUsername { get; set; }
    
    [JsonPropertyName("userProfilePic")]
    public string UserProfilePic { get; set; }
    
    [JsonPropertyName("userDisplayName")]
    public string UserDisplayName { get; set; }

    [JsonPropertyName("hashtags")]
    public List<string> Hashtags { get; set; }

}