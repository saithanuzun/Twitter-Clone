using MediatR;
using Twitter.Backend.Application.Features.Queries.User.GetUserFollowers;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Queries.User.GetUserFollowings;

public class GetUserFollowingsHandler : IRequestHandler<GetUserFollowingsRequest,GetUserFollowingsResponse>
{
    private IUserFollowRepository _followRepository;

    public GetUserFollowingsHandler(IUserFollowRepository followRepository)
    {
        _followRepository = followRepository;
    }

    public async Task<GetUserFollowingsResponse> Handle(GetUserFollowingsRequest request, CancellationToken cancellationToken)
    {
        var Followings = _followRepository.Get(i => i.FollowerId == request.FollowerUserId).Select(i => i.FollowingId)
            .ToList();

        return new GetUserFollowingsResponse() { UserFollowingIds = Followings };
    }
}

