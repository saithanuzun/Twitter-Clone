namespace Twitter.Backend.Domain.Entities;

public class User : BaseEntity
{
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }

    // One to one 
    public virtual UserProfile? Profile { get; private set; }

    // One to many tweets
    public virtual ICollection<Tweet> Tweets { get; private set; } = new List<Tweet>();

    // Self-reference 
    public virtual ICollection<UserFollow> Followers { get; private set; } = new List<UserFollow>();
    public virtual ICollection<UserFollow> Following { get; private set; } = new List<UserFollow>();

    // Many to many
    public virtual ICollection<TweetLike> TweetLikes { get; private set; } = new List<TweetLike>();

    // Constructor for EF Core
    protected User() { }

    public User(string username, string email, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException("Username cannot be empty", nameof(username));
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email cannot be empty", nameof(email));
        if (string.IsNullOrWhiteSpace(passwordHash)) throw new ArgumentException("Password cannot be empty", nameof(passwordHash));

        Username = username;
        Email = email;
        PasswordHash = passwordHash;
    }

    public void UpdatePassword(string newPasswordHash)
    {
        if (string.IsNullOrWhiteSpace(newPasswordHash)) throw new ArgumentException("Password cannot be empty", nameof(newPasswordHash));
        PasswordHash = newPasswordHash;
        UpdateModifiedDate();
    }

    public void UpdateEmail(string newEmail)
    {
        if (string.IsNullOrWhiteSpace(newEmail)) throw new ArgumentException("Email cannot be empty", nameof(newEmail));
        Email = newEmail;
        UpdateModifiedDate();
    }

    public void UpdateUsername(string newUsername)
    {
        if (string.IsNullOrWhiteSpace(newUsername)) throw new ArgumentException("Username cannot be empty", nameof(newUsername));
        Username = newUsername;
        UpdateModifiedDate();
    }

    public void SetProfile(UserProfile profile)
    {
        Profile = profile ?? throw new ArgumentNullException(nameof(profile));
        UpdateModifiedDate();
    }
}