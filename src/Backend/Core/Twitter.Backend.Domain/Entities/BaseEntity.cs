namespace Twitter.Backend.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }

    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }

    public bool IsDeleted { get; private set; }
    public DateTime? DeletedDate { get; private set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedDate = DateTime.UtcNow;
        ModifiedDate = DateTime.UtcNow;
    }

    public void UpdateModifiedDate()
    {
        ModifiedDate = DateTime.UtcNow;
    }

    public void Delete()
    {
        IsDeleted = true;
        DeletedDate = DateTime.UtcNow;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not BaseEntity other) return false;
        return Id == other.Id;
    }

    public override int GetHashCode() => Id.GetHashCode();
}
