using Asp_net_core_mvc.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

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