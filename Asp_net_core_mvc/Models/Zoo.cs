namespace Asp_net_core_mvc.Models
{
    public class Zoo
    {
        public int Id { get; set; }
        public string Name { get; set; } = "none";
        public int Workers_Ammount { get; set; }
        public int Aviary_Ammount { get; set; }

        public List<Ticket> Tickets { get; set; } = new();
    }
}
