using Asp_net_core_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Asp_net_core_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext db;
        public HomeController(ILogger<HomeController> logger, ApplicationContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public async Task<IActionResult> Index(decimal? minCost, decimal? maxCost, int page = 1, SortState sortOrder = SortState.CostAsc)
        {
            int pageSize = 3;

            IQueryable<Ticket> source = db.Ticket.Include(x => x.Zoo);

            if (minCost.HasValue)
            {
                source = source.Where(s => s.Cost >= minCost.Value);
            }

            if (maxCost.HasValue)
            {
                source = source.Where(s => s.Cost <= maxCost.Value);
            }

            var count = await source.CountAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ViewData["CostSort"] = sortOrder == SortState.CostAsc ? SortState.CostDesc : SortState.CostAsc;
            ViewData["DateSort"] = sortOrder == SortState.DateAsc ? SortState.DateDesc : SortState.DateAsc;
            ViewData["ZooSort"] = sortOrder == SortState.ZooAsc ? SortState.ZooDesc : SortState.ZooAsc;

            source = sortOrder switch
            {
                SortState.CostDesc => source.OrderByDescending(s => s.Cost),
                SortState.DateAsc => source.OrderBy(s => s.Date),
                SortState.DateDesc => source.OrderByDescending(s => s.Date),
                SortState.ZooAsc => source.OrderBy(s => s.Zoo_ID),
                SortState.ZooDesc => source.OrderByDescending(s => s.Zoo_ID),
                _ => source.OrderBy(s => s.Cost),
            };

            var items1 = await source.ToListAsync();

            var items = items1.Skip((page - 1) * pageSize).Take(pageSize);
            IndexViewModel viewModel = new IndexViewModel(items, pageViewModel);
            return View(viewModel);
        }
        public IActionResult CreateTicket()
        {
            var zooIds = db.Zoo.Select(z => z.Id).ToList();
            ViewBag.ZooIds = new SelectList(zooIds);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTicket(Ticket ticket, int selectedZooId)
        {
            if (ModelState.IsValid)
            {
                ticket.Zoo = await db.Zoo.FirstOrDefaultAsync(z => z.Id == selectedZooId);
                db.Ticket.Add(ticket);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ticket);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteTicket(int? id)
        {
            if (id != null)
            {
                Ticket? ticket = await db.Ticket.FirstOrDefaultAsync(p => p.Id == id);
                if (ticket != null)
                {
                    db.Ticket.Remove(ticket);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> EditTicket(int? id)
        {
            if (id != null)
            {
                Ticket? ticket = await db.Ticket.FirstOrDefaultAsync(p => p.Id == id);
                var zooIds = db.Zoo.Select(z => z.Id).ToList();
                ViewBag.ZooIds = new SelectList(zooIds);
                if (ticket != null) return View(ticket);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditTicket(Ticket ticket, int selectedZooId)
        {
            if (ModelState.IsValid)
            {
                ticket.Zoo = await db.Zoo.FirstOrDefaultAsync(z => z.Id == selectedZooId);
                db.Ticket.Update(ticket);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ticket);
        }

        public IActionResult CreateZoo()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateZoo(Zoo zoo)
        {
            db.Zoo.Add(zoo);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteZoo(int? id)
        {
            if (id != null)
            {
                Zoo? zoo = await db.Zoo.FirstOrDefaultAsync(p => p.Id == id);
                if (zoo != null)
                {
                    db.Zoo.Remove(zoo);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> EditZoo(int? id)
        {
            if (id != null)
            {
                Zoo? zoo = await db.Zoo.FirstOrDefaultAsync(p => p.Id == id);
                if (zoo != null) return View(zoo);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditZoo(Zoo zoo)
        {
            db.Zoo.Update(zoo);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}