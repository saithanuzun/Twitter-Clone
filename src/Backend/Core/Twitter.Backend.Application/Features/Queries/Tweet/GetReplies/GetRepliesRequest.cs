using MediatR;

namespace Twitter.Backend.Application.Features.Queries.Tweet.GetReplies;

public class GetRepliesRequest : IRequest<GetRepliesResponse>   
{
    public Guid TweetId { get; set; }
}