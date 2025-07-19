namespace Twitter.BlazorApp.Infrastructure.Models.ViewModels;

public class TweetViewModel
{
    public string Id { get; set; }
    public string Username { get; set; } 
    public string ProfileName { get; set; } 
    public string Time { get; set; } 
    public string Content { get; set; } 
    public string ProfilePic { get; set; } 
    public string MediaUrl { get; set; } 

    public int RepliesCount { get; set; }
    public int RetweetsCount { get; set; }
    public int LikesCount { get; set; }

    public List<string> Hashtags { get; set; }
}