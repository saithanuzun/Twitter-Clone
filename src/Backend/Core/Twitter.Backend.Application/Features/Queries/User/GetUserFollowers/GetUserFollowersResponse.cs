namespace Twitter.Backend.Application.Features.Queries.User.GetUserFollowers;

public class GetUserFollowersResponse
{
    public List<Guid> FollowingUserIds { get; set; }
}