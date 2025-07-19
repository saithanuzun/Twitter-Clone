using Twitter.Backend.Application.Features.Queries.Tweet.GetTweet;

namespace Twitter.Backend.Application.Features.Queries.Tweet.GetMainPageTweets;

public class GetMainPageTweetsResponse
{
    public DateTime CreatedDate { get; set; }
    public Guid Id { get; set; }
    public string Content { get; set; }
    public string? MediaUrl { get; set; }
    
    public bool? IsDeleted { get; set; }
    public DateTime? DeletedDate { get; set; }
    
    public Guid? ParentTweetId { get; set; }

    public Guid UserId { get; set; }
    public bool? IsRetweet { get; set; }
    public Guid? RetweetParentId { get; set; }
    
    public int RetweetCount { get; set; }
    public int LikeCount { get; set; }
    public int RepliesCount{ get; set; }
    public string UserUsername { get; set; }
    public string UserProfilePic { get; set; }
    public string UserDisplayName { get; set; }

    public List<string> Hashtags { get; set; }
}