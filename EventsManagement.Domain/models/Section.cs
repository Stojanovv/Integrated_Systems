namespace EventsManagement.Domain;

public class Section : BaseEntity
{
    public string Name { get; set; }
    public int Capacity { get; set; }
    
    public Guid VenueId { get; set; }
    public virtual Venue Venue { get; set; } = null!;

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();

    public virtual ICollection<EventSectionPricing> EventSectionPricings { get; set; } =
        new List<EventSectionPricing>();
}