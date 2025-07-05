using MediatR;

namespace Twitter.Backend.Application.Features.Queries.User.GetUserFollowers;

public class GetUserFollowersRequest : IRequest<GetUserFollowersResponse>
{
    public Guid? FollowingId { get; set; }
    public string? Username { get; set; }
}