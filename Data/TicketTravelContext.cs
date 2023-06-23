using Microsoft.EntityFrameworkCore;
using TicketTravel.Models;

namespace TicketTravel.Data
{
    public class TicketTravelContext : DbContext
    {
        public TicketTravelContext(DbContextOptions options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookingTicket> BookingTickets { get; set; }
        public DbSet<HistoryBooking> HistoryBookings { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Transportation> Transportations { get; set; }
        public DbSet<TransportationType> TransportationTypes { get; set; }
    }
}
