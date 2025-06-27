namespace Twitter.Backend.Domain.Entities;

public class UserProfile : BaseEntity
{
    public string ProfileName { get; set; }
    public string Bio { get; set; }
    public string Location { get; set; }
    public string ImageUrl { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }

}