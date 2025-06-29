using AutoMapper;
using MediatR;
using Twitter.Backend.Application.Encryptor;
using Twitter.Backend.Domain.Entities;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Commands.User.Create;

public class CreateUserHandler : IRequestHandler<CreateUserRequest,CreateUserResponse>
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

        Domain.Entities.User dbUser = new Domain.Entities.User()
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = request.Password,
            Profile = new UserProfile()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Bio = request.Bio,
                Location = request.Location,
                ImageUrl = request.ImageUrl,
            }
        };

        await _userRepository.AddAsync(dbUser);

        return new CreateUserResponse() { Id = dbUser.Id };
    }
}