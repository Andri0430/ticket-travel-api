using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketTravel.Models
{
    public class Transportation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NameTransportation { get; set; } = string.Empty;
        public TransportationType TransportationType { get; set; }
        public int seat { get; set; }
    }
}