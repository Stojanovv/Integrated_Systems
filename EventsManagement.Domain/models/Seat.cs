namespace EventsManagement.Domain;

public class Seat : BaseEntity
{
    public int Row { get; set; }
    public int RowNumber { get; set; }
    public string Label { get; set; } = string.Empty;
    public bool IsAccessible { get; set; }
    
    public Guid SectionId { get; set; }
    public virtual Section Section { get; set; } = null!;

    public virtual ICollection<SeatReservation> SeatReservations { get; set; }= new List<SeatReservation>();
}