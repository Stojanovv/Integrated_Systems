namespace EventsManagement.Domain;

public class EventSectionPricing : BaseAuditableEntity<EventAppUser>
{
    public decimal Price { get; set; }
    public string Currency { get; set; } = "USD";
    
    public Guid EventId { get; set; }
    public virtual Event Event { get; set; } = null!;
    
    public Guid SectionId { get; set; }
    public virtual Section Section { get; set; } = null!;
}