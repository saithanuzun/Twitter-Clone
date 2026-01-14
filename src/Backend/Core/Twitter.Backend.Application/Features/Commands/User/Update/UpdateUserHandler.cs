using AutoMapper;
using MediatR;
using Twitter.Backend.Domain.Entities;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Commands.User.Update;

public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
{
    private IUserRepository _userRepository;
    private IMapper _mapper;

    public UpdateUserHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var dbUser = await _userRepository.GetByIdAsync(request.Id);
        if (dbUser is null)
            throw new Exception("user not found");

        dbUser.UpdateUsername(request.Username);
        dbUser.UpdateEmail(request.Email);
        dbUser.UpdatePassword(request.Password);

        if (dbUser.Profile != null)
        {
            dbUser.Profile.UpdateName(request.FirstName, request.LastName);
            dbUser.Profile.UpdateInfo(request.DisplayName, request.Bio, request.Location, request.ImageUrl);
        }

        await _userRepository.UpdateAsync(dbUser);

        return new UpdateUserResponse() { GuidId = dbUser.Id };

    }

}