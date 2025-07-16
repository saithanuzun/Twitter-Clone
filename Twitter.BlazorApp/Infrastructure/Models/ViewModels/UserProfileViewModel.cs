namespace Twitter.BlazorApp.Infrastructure.Models.ViewModels;

public class UserProfileViewModel
{
    public string FullName { get; set; }
    public string Handle { get; set; } // without '@'
    public string Bio { get; set; }
    public string BannerImageUrl { get; set; }
    public string ProfileImageUrl { get; set; }
    public string Location { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime JoinDate { get; set; }
    public int FollowersCount { get; set; }
    public int FollowingCount { get; set; }
    public bool IsFollowing { get; set; }
}
