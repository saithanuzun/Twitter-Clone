using System.Security.Claims;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Twitter.Backend.Application.Encryptor;
using Twitter.Backend.Application.Jwt;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Commands.User.Login;

public class LoginHandler : IRequestHandler<LoginRequest,LoginResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public LoginHandler(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var passwordHash = PasswordEncryptor.Encrypt(request.Password);
        var dbUser = await _userRepository.GetSingleAsync(i => i.Email == request.Email && i.PasswordHash == passwordHash);

        if (dbUser is null)
            return null;
        
        var result = _mapper.Map<LoginResponse>(dbUser);

        
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, dbUser.Id.ToString()),
            new Claim(ClaimTypes.Name, dbUser.Username),
            new Claim(ClaimTypes.Email, dbUser.Email),
        };

        result.Token = TokenGenerator.GenerateToken(claims, _configuration["AuthConfig:Secret"]);

        return result;
    }
}