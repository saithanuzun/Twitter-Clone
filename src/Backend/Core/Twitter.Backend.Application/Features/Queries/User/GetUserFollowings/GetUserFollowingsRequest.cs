using MediatR;

namespace Twitter.Backend.Application.Features.Queries.User.GetUserFollowings;

public class GetUserFollowingsRequest : IRequest<GetUserFollowingsResponse>
{
    public Guid FollowerUserId { get; set; }
}