using System.Text.Json.Serialization;

namespace Twitter.BlazorApp.Infrastructure.Models.Dvos;

using System;
using System.Collections.Generic;

public class TweetLikeDvo
{
    [JsonPropertyName("tweetId")]
    public string TweetId { get; set; }
    
    [JsonPropertyName("userIds")]
    public List<string> UserIds { get; set; }
    
    [JsonPropertyName("likesCount")]
    public int LikesCount { get; set; }
}
