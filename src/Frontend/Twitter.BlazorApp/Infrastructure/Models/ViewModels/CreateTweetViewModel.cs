namespace Twitter.BlazorApp.Infrastructure.Models.ViewModels;

public class CreateTweetViewModel
{
    public Guid UserId { get; set; }
    public Guid? ParentTweetId { get; set; }
}