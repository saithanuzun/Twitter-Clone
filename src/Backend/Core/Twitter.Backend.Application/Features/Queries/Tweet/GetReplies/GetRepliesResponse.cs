namespace Twitter.Backend.Application.Features.Queries.Tweet.GetReplies;

public class GetRepliesResponse
{
    public List<Domain.Entities.Tweet> Replies { get; set; }
}