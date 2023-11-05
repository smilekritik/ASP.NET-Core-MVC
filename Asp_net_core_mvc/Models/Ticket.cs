using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Asp_net_core_mvc.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        public Zoo? Zoo { get; set; }
        [ForeignKey("Zoo_ID")]
        public int? Zoo_ID { get; set; }

        public decimal Cost { get; set; }
        public DateTime Date { get; set; }

        public List<Customer> Customers { get; set; } = new();
        public List<Aviary> Aviaries { get; set; } = new();
    }
}
