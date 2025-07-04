using AutoMapper;
using MediatR;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Commands.User.DeleteFollow;

public class DeleteFollowHandler : IRequestHandler<DeleteFollowRequest,DeleteFollowResponse>
{
    private readonly IUserFollowRepository _userFollowRepository;
    private IMapper _mapper;

    public DeleteFollowHandler(IUserFollowRepository userFollowRepository, IMapper mapper)
    {
        _userFollowRepository = userFollowRepository;
        _mapper = mapper;
    }

    public async Task<DeleteFollowResponse> Handle(DeleteFollowRequest request, CancellationToken cancellationToken)
    {
        var dbFollow = await _userFollowRepository
            .GetSingleAsync(i => i.Id == request.Id);
        
        await _userFollowRepository.DeleteAsync(dbFollow);

        return new DeleteFollowResponse() { Id = dbFollow.Id };
        
    }
}