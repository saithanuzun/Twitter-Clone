using MediatR;

namespace Twitter.Backend.Application.Features.Commands.User.Create;

public class CreateUserRequest : IRequest<CreateUserResponse>
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Bio { get; set; }
    public string Location { get; set; }
    public string ImageUrl { get; set; }
}