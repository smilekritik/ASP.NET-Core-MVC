namespace Asp_net_core_mvc.Models
{
    public class Aviary
    {
        public int Id { get; set; }

        public List<Type_Animal> Type_Animals { get; set; } = new();

        public int Animals_Ammount { get; set; }

        public List<Worker> Workers { get; set; } = new();
        public int? Ticket_ID { get; set; }
        public Ticket? Ticket { get; set; }
        public List<Animal> Animals { get; set; } = new();
    }
}
