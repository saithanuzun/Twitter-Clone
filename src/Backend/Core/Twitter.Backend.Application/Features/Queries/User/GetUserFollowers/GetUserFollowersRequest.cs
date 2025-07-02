using MediatR;

namespace Twitter.Backend.Application.Features.Queries.User.GetUserFollowers;

public class GetUserFollowersRequest : IRequest<GetUserFollowersResponse>
{
    public Guid UserId { get; set; }
}