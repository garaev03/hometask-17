using hometask_17.DAL.Models;
using hometask_17.Models;
using hometask_17.ViewModels;
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
            WorkVM work = new()
            {
                Categories = await _context.WorkCategories
                         .Where(c => c.isDeleted == false)
                         .ToListAsync(),
                Products = await _context.WorkProducts
                     .Take(3)
                     .Where(p => p.isDeleted == false)
                     .Include(x => x.Images)
                     .ToListAsync()
            };

            return View(work);
        }

        public async Task<IActionResult> Single(int id)
        {
            List<WorkProduct> products = await _context.WorkProducts.Include(x => x.Images).ToListAsync();
            WorkProduct product = products.Find(x => x.Id == id);

            return View(product);
        }

        public async Task<IActionResult> LoadMore(int skip,int take)
        {
            var Products = await _context.WorkProducts
                       .Skip(skip)
                       .Take(take)
                       .Where(p => p.isDeleted == false)
                       .Include(x => x.Images)
                       .Include(x=>x.Category)
                       .ToListAsync();

            return PartialView("_WorkProductsPartialView", Products);
        }

        public async Task<int> GetProductsCount()
        {
           var Products= await _context.WorkProducts
                        .Where(p => p.isDeleted == false)
                        .ToListAsync();

            var productsCount = Products.Count;
            return productsCount;
        }
    }
}

