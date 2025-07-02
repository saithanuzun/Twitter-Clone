using MediatR;

namespace Twitter.Backend.Application.Features.Queries.User.GetUserTweets;

public class GetUserTweetsRequest : IRequest<GetUserTweetsResponse>
{
    public Guid UserId { get; set; }
}