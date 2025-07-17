namespace Twitter.BlazorApp.Infrastructure.Models.ViewModels;

public class UserFollowViewModel
{
    public UserProfileViewModel User { get; set; }
    public bool IsFollowing { get; set; }
}