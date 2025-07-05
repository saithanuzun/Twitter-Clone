namespace Twitter.Backend.Application.Features.Queries.User.GetUserFollowings;

public class GetUserFollowingsResponse
{
    public List<Guid> UserFollowingIds { get; set; }
    public List<string> Usernames { get; set; }
}