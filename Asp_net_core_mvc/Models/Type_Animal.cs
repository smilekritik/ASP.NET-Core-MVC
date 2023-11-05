namespace Asp_net_core_mvc.Models
{
    public class Type_Animal
    {
        public int Id { get; set; }
        public string Type { get; set; } = "none";
        public string Specifics { get; set; } = "none";

        public Aviary? Aviary { get; set; }
        public string? SomeInfo { get; set; }
    }
}
