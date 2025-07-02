using AutoMapper;
using MediatR;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Queries.User.GetUser;

public class GetUserHandler : IRequestHandler<GetUserRequest,GetUserResponse>
{
    private IUserRepository _userRepository;
    private IMapper _mapper;

    public GetUserHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetSingleAsync(i => i.Id == request.Id);

        return _mapper.Map<GetUserResponse>(user);
    }
}