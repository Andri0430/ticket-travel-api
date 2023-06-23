using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicketTravel.Models;

namespace TicketTravel.Models
{
    public class BookingTicket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBooking { get; set; }
        public Ticket Ticket { get; set; }
        public ICollection<User> UserBooking { get; set; }
    }
}