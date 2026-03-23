namespace EventsManagement.Domain;

public class Ticket : BaseEntity
{
    public TicketStatus Status { get; set; }
    public DateTime IssuedAt { get; set; }
    
    public Guid SeatReservationId { get; set; }
    public virtual SeatReservation SeatReservation { get; set; } = null!;
    
    public Guid UserId { get; set; }
    public virtual EventAppUser User { get; set; } = null!;
    
    public Guid EventId { get; set; }
    public virtual Event Event { get; set; } = null!;
}