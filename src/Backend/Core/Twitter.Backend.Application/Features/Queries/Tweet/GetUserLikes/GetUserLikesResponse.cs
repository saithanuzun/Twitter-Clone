namespace Twitter.Backend.Application.Features.Queries.User.GetUserLikes;

public class GetUserLikesResponse
{
    public Guid? UserId { get; set; }
    public string? Username { get; set; }
    public List<Guid> TweetIds{ get; set; }
}