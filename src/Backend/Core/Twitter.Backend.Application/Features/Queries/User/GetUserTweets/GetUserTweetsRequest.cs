using MediatR;
using Twitter.Backend.Application.Pagination;

namespace Twitter.Backend.Application.Features.Queries.User.GetUserTweets;

public class GetUserTweetsRequest : PagedQuery, IRequest<GetUserTweetsResponse>
{
    public Guid? UserId { get; set; }
    public string? username { get; set; }
}