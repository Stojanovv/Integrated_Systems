using EventsManagement.Domain;

namespace EventMenagement.Repository;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{
    public DbSet<EventAppUser> EventAppUsers { get; set; }
    public DbSet<Venue> Venues { get; set; }
    public DbSet<Section>  Sections { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<EventSectionPricing> EventSectionPricings { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<SeatReservation> SeatReservations { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    
}