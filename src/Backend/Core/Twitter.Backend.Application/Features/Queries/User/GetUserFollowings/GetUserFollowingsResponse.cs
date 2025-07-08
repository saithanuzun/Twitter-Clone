namespace Twitter.Backend.Application.Features.Queries.User.GetUserFollowings;

public class GetUserFollowingsResponse
{
    public List<Guid>? UserFollowingIds { get; set; }
    public List<string>? Usernames { get; set; }
    public int FollowingsCount { get; set; } = 0;
    public string? Username { get; set; }
    public Guid? UserId { get; set; }
}