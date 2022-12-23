using hometask_17.DAL.Models;
using hometask_17.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hometask_17.Controllers
{
    public class WorkController : Controller
    {
        private readonly PurpleBuzzDbContext? _context;
        public WorkController(PurpleBuzzDbContext? context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var Category = await _context.WorkCategories
                .Include(x=>x.Products)
                .ToListAsync();

            return View(Category);
        }
    }
}
