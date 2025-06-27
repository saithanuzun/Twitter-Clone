namespace Twitter.Backend.Domain.Entities;

public class BaseEntity
{
    public Guid Id { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedDate { get; set; }
}