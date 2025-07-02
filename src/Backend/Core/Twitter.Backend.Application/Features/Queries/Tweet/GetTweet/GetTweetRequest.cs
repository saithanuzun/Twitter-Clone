using MediatR;

namespace Twitter.Backend.Application.Features.Queries.Tweet.GetTweet;

public class GetTweetRequest : IRequest<GetTweetResponse>
{
    public Guid Id { get; set; }
}