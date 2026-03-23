namespace EventsManagement.Domain.dto;

public class ReservationDto:BaseEntity
{
    public DateTime ReservationAt { get; set; }
    public DateTime ExpiresAd { get; set; }
    public ReservationStatus Status { get; set; }
    
    public Guid UserId { get; set; }
    
    public Guid EventId { get; set; }
}