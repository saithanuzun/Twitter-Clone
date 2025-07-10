using AutoMapper;
using MediatR;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Queries.User.GetFollowSuggestions;

public class FollowSuggestionHandler : IRequestHandler<FollowSuggestionRequest,FollowSuggestionResponse>
{
    private readonly IUserRepository _userRepository;
    private IUserFollowRepository _followRepository;
    private readonly IMapper _mapper;

    public FollowSuggestionHandler(IUserRepository userRepository, IMapper mapper, IUserFollowRepository followRepository)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _followRepository = followRepository;
    }

    public async Task<FollowSuggestionResponse> Handle(FollowSuggestionRequest request, CancellationToken cancellationToken)
    {
        var  followers = _followRepository
            .Get(i => i.FollowingId == request.UserId)
            .Select(i=>i.FollowerId)
            .ToList();
        
        var followings = _followRepository
            .Get(i => i.FollowerId == request.UserId)
            .Select(i => i.FollowingId)
            .ToList();

        var notFollowingBack = followers.Except(followings).ToList();

        if (!notFollowingBack.Any())
        {
            var randomThree = _userRepository.Get(i=>true)
                .OrderBy(x => Guid.NewGuid())
                .Select(i=>i.Id)
                .Take(5)
                .ToList();
            
            notFollowingBack.AddRange(randomThree);
        }

        return new FollowSuggestionResponse()
        {
            UserIds = notFollowingBack
        };
    }
}