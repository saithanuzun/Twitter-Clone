namespace Twitter.Backend.Application.Features.Queries.User.GetUser;

public class GetUserResponse
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Bio { get; set; }
    public string Location { get; set; }
    public string ImageUrl { get; set; }
}