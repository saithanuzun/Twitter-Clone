namespace Twitter.Backend.Application.Features.Queries.User.GetUserReplies;

public class GetUserRepliesResponse
{
    public Guid? UserId { get; set; }
    public string? Username { get; set; }
    public List<Guid> TweetIds{ get; set; }
}