using AutoMapper;
using MediatR;
using Twitter.Backend.Domain.Entities;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Commands.User.CreateFollow;

public class CreateFollowHandler :IRequestHandler<CreateFollowRequest,CreateFollowResponse>
{
    private IUserFollowRepository _userFollowRepository;
    private IMapper _mapper;

    public CreateFollowHandler(IUserFollowRepository userFollowRepository, IMapper mapper)
    {
        _userFollowRepository = userFollowRepository;
        _mapper = mapper;
    }

    // todo : add validation You cannot follow yourself, you cannot follow second time same person
    public async Task<CreateFollowResponse> Handle(CreateFollowRequest request, CancellationToken cancellationToken)
    {
        var dbFollow = _mapper.Map<UserFollow>(request);

        await _userFollowRepository.AddAsync(dbFollow);

        return new CreateFollowResponse() { Id = dbFollow.Id };
    }
}