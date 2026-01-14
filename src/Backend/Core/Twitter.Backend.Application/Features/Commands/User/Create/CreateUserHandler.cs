using AutoMapper;
using MediatR;
using Twitter.Backend.Application.Encryptor;
using Twitter.Backend.Domain.Entities;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Commands.User.Create;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private IUserRepository _userRepository;
    private IMapper _mapper;

    public CreateUserHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {

        var existUser = await _userRepository.GetSingleAsync(i => i.Email == request.Email);

        if (existUser is not null)
            throw new Exception("User Already Exist");

        request.Password = PasswordEncryptor.Encrypt(request.Password);

        var dbUser = new Domain.Entities.User(request.Username, request.Email, request.Password);

        var profile = new UserProfile(dbUser.Id, request.FirstName, request.LastName);
        profile.UpdateInfo(request.DisplayName, request.Bio, request.Location, request.ImageUrl);

        dbUser.SetProfile(profile);

        await _userRepository.AddAsync(dbUser);

        return new CreateUserResponse() { Id = dbUser.Id };
    }
}