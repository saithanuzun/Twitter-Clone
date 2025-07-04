using MediatR;

namespace Twitter.Backend.Application.Features.Commands.User.Login;

public class LoginHandler : IRequestHandler<LoginRequest,LoginResponse>
{
    // TODO: Implement the login functionality.

    public Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}