namespace Twitter.Backend.Application.Features.Queries.Tweet.GetTweet;

public class GetTweetResponse 
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    
    public bool IsDeleted { get; set; }
    public DateTime DeletedDate { get; set; }
    
    public Guid? ParentTweetId { get; set; }

    public Guid UserId { get; set; }
    public bool IsRetweet { get; set; }
    
    public Guid? RetweetParentId { get; set; }

}