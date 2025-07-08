namespace Twitter.Backend.Application.Features.Queries.User.GetUserFollowers;

public class GetUserFollowersResponse
{
    public List<Guid>? FollowingUserIds { get; set; }
    public List<string>? Usernames { get; set; }
    public int FollowersCount { get; set; } = 0;
    public string? Username { get; set; }
    public Guid? UserId { get; set; }
}