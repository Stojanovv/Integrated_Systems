namespace EventsManagement.Domain;

public abstract class BaseEntity
{
    public Guid Id { get; set; } = default!;
}