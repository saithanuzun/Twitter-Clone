using MediatR;

namespace Twitter.Backend.Application.Features.Commands.User.Login;

public class LoginRequest : IRequest<LoginResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}