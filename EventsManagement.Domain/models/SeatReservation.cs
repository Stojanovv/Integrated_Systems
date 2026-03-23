namespace EventsManagement.Domain;

public class SeatReservation : BaseEntity
{
    public Guid SeatId { get; set; }
    public virtual Seat Seat { get; set; } = null!;
    
    public Guid EventId { get; set; }
    public virtual Event Event { get; set; } = null!;
    
    public Guid ReservationId { get; set; }
    public virtual Reservation Reservation { get; set; } = null!;
    
    public Guid TicketId { get; set; }
    public virtual Ticket Ticket { get; set; } = null!;

}