using System.ComponentModel.DataAnnotations;

namespace Asp_net_core_mvc.Models
{
    public class Zoo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не встановлена назва")]
        public string Name { get; set; } = "none";
        [Required(ErrorMessage = "Не встановлена кількість робочих")]
        [Range(0, 100, ErrorMessage = "Кількість робочих повинна бути в діапазоні 0-100")]
        public int Workers_Ammount { get; set; }
        [Required(ErrorMessage = "Не встановлена кількість воль'єрів")]
        public int Aviary_Ammount { get; set; }

        public List<Ticket> Tickets { get; set; } = new();
    }
}
