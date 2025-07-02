using MediatR;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Queries.User.GetUserFollowers;

public class GetUserFollowersHandler : IRequestHandler<GetUserFollowersRequest,GetUserFollowersResponse>
{
    private IUserFollowRepository _followRepository;
    
    public async Task<GetUserFollowersResponse> Handle(GetUserFollowersRequest request, CancellationToken cancellationToken)
    {
        var followingUserIds = _followRepository.Get(i => i.FollowingId == request.UserId)
            .Select(i=>i.FollowingId).ToList();

        return new GetUserFollowersResponse() { FollowingUserIds = followingUserIds};
    }
}