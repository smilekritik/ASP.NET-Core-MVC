namespace Asp_net_core_mvc.Models
{
    public class Animal
    {
        public int Id { get; set; }

        public int Aviary_ID { get; set; }
        public Aviary? Aviary { get; set; }
        public string Name { get; set; } = "none";
        public int Age { get; set; }
        public float Weight { get; set; }
        public string Sex { get; set; } = "none";
        public int? Type_Animal_ID { get; set; }
    }
}
