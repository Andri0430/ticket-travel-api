using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketTravel.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Transportation Transportation { get; set; }
        public string Destination { get; set; }
        public DateOnly Schedule { get; set; }
        public TimeOnly Time { get; set; }
    }
}