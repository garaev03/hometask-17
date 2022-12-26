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
                .Include(x => x.Products.Where(p => p.isDeleted ==  false )).ThenInclude(x=>x.Images)
                .Where(x => x.isDeleted == false)
                .ToListAsync();

            return View(Category);
        }

        public async Task<IActionResult> Single(int id)
        {
            List<WorkProduct> products= await _context.WorkProducts.Include(x=>x.Images).ToListAsync();
            WorkProduct product = products.Find(x=>x.Id==id);

            return View(product);
        }
    }
}
