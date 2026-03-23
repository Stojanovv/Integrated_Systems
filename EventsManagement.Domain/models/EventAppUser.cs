namespace EventsManagement.Domain;

public class EventAppUser : BaseEntity
{
    public string FirstName=string.Empty;
    public string LastName=string.Empty;
    public string Email=string.Empty;
    public string PhoneNumber=string.Empty;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
    public virtual ICollection<Reservation>Reservations { get; set; } = new List<Reservation>();
    public virtual ICollection<Ticket>Tickets { get; set; } = new List<Ticket>();
}