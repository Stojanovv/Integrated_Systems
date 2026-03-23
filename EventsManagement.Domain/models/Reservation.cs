namespace EventsManagement.Domain;

public class Reservation : BaseAuditableEntity<EventAppUser>
{
    public DateTime ReservationAt { get; set; }
    public DateTime ExpiresAd { get; set; }
    public ReservationStatus Status { get; set; }

    public virtual ICollection<SeatReservation> SeatReservations { get; set; } = new List<SeatReservation>();
    
    public Guid UserId { get; set; }
    public virtual EventAppUser User { get; set; } = null!;
    
    public Guid EventId { get; set; }
    public virtual Event Event { get; set; } = null!;
}