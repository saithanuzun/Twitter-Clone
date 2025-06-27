namespace Twitter.Backend.Domain.Entities;

public class UserFollow : BaseEntity
{
    public Guid FollowerId { get; set; }     // who follows
    public User Follower { get; set; }

    public Guid FollowingId { get; set; }    // who is being followed
    public User Following { get; set; }

}