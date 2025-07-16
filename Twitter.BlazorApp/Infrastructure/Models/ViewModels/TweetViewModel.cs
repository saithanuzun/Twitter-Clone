namespace Twitter.BlazorApp.Infrastructure.Models.ViewModels;

public class TweetViewModel
{
    public Guid Id { get; set; }
    public string Username { get; set; } 
    public string ProfileName { get; set; } 
    public string Time { get; set; } 
    public string Content { get; set; } 
    public string ProfilePic { get; set; } 
    public string MediaUrl { get; set; } 

    public int RepliesCount { get; set; }
    public int RetweetsCount { get; set; }
    public int LikesCount { get; set; }
}