using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Asp_net_core_mvc.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Ticket> Tickets { get; }
        public PageViewModel PageViewModel { get; }
        public decimal? minCost { get; set; }
        public decimal? maxCost { get; set; }
        public IndexViewModel(IEnumerable<Ticket> tickets, PageViewModel viewModel)
        {
            Tickets = tickets;
            PageViewModel = viewModel;
        }
    }
}