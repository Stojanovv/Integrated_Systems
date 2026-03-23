namespace EventsManagement.Domain;

public class Event : BaseEntity
{
    public string Title { get; set; }=string.Empty;
    public string Description { get; set; }=string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Status { get; set; }
    public string BannerUrl { get; set; }=string.Empty;
    
    public Guid VenueId { get; set; }
    public virtual Venue Venue { get; set; } = null!;
    
    public Guid UserId { get; set; }
    public virtual EventAppUser User { get; set; } = null!;
    
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    public virtual ICollection<Ticket> Events { get; set; } = new List<Ticket>();
    public virtual ICollection<SeatReservation> ReservationsForEvent { get; set; } = new List<SeatReservation>();
    public virtual ICollection<EventSectionPricing> ReservationsForSeat { get; set; } = new List<EventSectionPricing>();
}