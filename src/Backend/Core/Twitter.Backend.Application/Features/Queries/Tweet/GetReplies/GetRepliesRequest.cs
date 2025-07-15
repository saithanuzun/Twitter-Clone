using MediatR;

namespace Twitter.Backend.Application.Features.Queries.Tweet.GetReplies;

public class GetRepliesRequest : IRequest<List<GetRepliesResponse>>
{
    public Guid TweetId { get; set; }
}