namespace Twitter.Backend.Application.Features.Commands.User.Login;

public class LoginResponse
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Token { get; set; }
    
}