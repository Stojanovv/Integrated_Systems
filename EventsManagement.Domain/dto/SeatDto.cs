namespace EventsManagement.Domain.dto;

public class SeatDto
{
    public int Row { get; set; }
    public int RowNumber { get; set; }
    public string? Label { get; set; } 
    public bool IsAccessible { get; set; }
    
    public Guid SectionId { get; set; }
}