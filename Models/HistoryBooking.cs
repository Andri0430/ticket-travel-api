using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicketTravel.Models;

namespace TicketTravel.Models
{
    public class HistoryBooking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHistoryBooking { get; set; }
        public User User { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
