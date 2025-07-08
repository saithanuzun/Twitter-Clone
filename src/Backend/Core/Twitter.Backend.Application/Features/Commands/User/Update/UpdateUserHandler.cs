using AutoMapper;
using MediatR;
using Twitter.Backend.Domain.Entities;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Commands.User.Update;

public class UpdateUserHandler : IRequestHandler<UpdateUserRequest,UpdateUserResponse>
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
        
        Domain.Entities.User updatedUser = new Domain.Entities.User()
        {
            Id = dbUser.Id,
            Username = request.Username,
            Email = request.Email,
            PasswordHash = request.Password,
            Profile = new UserProfile()
            {
                Id = dbUser.Profile.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DisplayName = request.DisplayName,
                Bio = request.Bio,
                Location = request.Location,
                ImageUrl = request.ImageUrl,
            }
        };

        await _userRepository.UpdateAsync(updatedUser);

        return new UpdateUserResponse() { GuidId = dbUser.Id };

    }
    
}