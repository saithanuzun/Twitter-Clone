namespace Twitter.Backend.Domain.Entities;

public class UserProfile : BaseEntity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public string DisplayName { get; private set; }
    public string Bio { get; private set; }
    public string Location { get; private set; }
    public string ImageUrl { get; private set; }

    public Guid UserId { get; private set; }
    public User User { get; private set; }

    // Constructor for EF Core
    protected UserProfile() { }

    public UserProfile(Guid userId, string firstName, string lastName)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        DisplayName = $"{firstName} {lastName}";
        Bio = string.Empty;
        Location = string.Empty;
        ImageUrl = string.Empty;
    }

    public void UpdateName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        UpdateModifiedDate();
    }

    public void UpdateInfo(string displayName, string bio, string location, string imageUrl)
    {
        DisplayName = displayName;
        Bio = bio;
        Location = location;
        ImageUrl = imageUrl;
        UpdateModifiedDate();
    }
}