namespace EventsManagement.Domain.dto;

public class EventDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Status { get; set; }
    public string? BannerUrl { get; set; }
    
    public Guid VenueId { get; set; }
    
    public Guid UserId { get; set; }
}