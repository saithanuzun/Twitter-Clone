using MediatR;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Queries.User.GetUserFollowers;

public class GetUserFollowersHandler : IRequestHandler<GetUserFollowersRequest,GetUserFollowersResponse>
{
    private IUserFollowRepository _followRepository;

    public GetUserFollowersHandler(IUserFollowRepository followRepository)
    {
        _followRepository = followRepository;
    }

    public async Task<GetUserFollowersResponse> Handle(GetUserFollowersRequest request, CancellationToken cancellationToken)
    {
        var followingUserIds = _followRepository
            .Get(i => i.FollowingId == request.FollowingId)
            .Select(i=>i.FollowerId)
            .ToList();
        
        var followingUserNames = _followRepository
            .Get(i => i.Following.Username == request.Username)
            .Select(i=>i.Follower.Username)
            .ToList();


        return new GetUserFollowersResponse()
        {
            FollowingUserIds = followingUserIds,
            FollowersCount = followingUserIds.Count, 
            Username = request.Username, 
            UserId = request.FollowingId,
            Usernames = followingUserNames,
        };
    }
}