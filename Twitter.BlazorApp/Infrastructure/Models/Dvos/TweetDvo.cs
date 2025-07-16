namespace Twitter.BlazorApp.Infrastructure.Models.Dvos;

public class TweetDvo
{
    public DateTime CreatedDate { get; set; }
    public string Id { get; set; }
    public string Content { get; set; }
    public string MediaUrl { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime DeletedDate { get; set; }
    public string? ParentTweetId { get; set; }
    public string UserId { get; set; }
    public bool IsRetweet { get; set; }
    public string? RetweetParentId { get; set; }
    public int RetweetCount { get; set; }
    public int LikeCount { get; set; }
    public int RepliesCount { get; set; }
    public string UserUsername { get; set; }
    public string UserProfilePic { get; set; }
    public string UserDisplayName { get; set; }

}