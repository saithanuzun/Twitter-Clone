namespace Twitter.Frontend.BlazorApp.Infrastructure.Models.Dtos;

public class CreateTweetDto
{
    public string Content { get; set; }
    
    public Guid? ParentTweetId { get; set; }
    
    public Guid UserId { get; set; }
    
    public bool? IsRetweet { get; set; }
    
    public Guid? RetweetParentId { get; set; }
}