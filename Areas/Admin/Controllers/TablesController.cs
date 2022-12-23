using hometask_17.DAL.Models;
using hometask_17.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hometask_17.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TablesController : Controller
    {
        private readonly PurpleBuzzDbContext _context;

        public TablesController(PurpleBuzzDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Categories()
        {
            List<WorkCategory> categories = await _context.WorkCategories
                .Include(x => x.Products)
                .OrderBy(c => c.Id)
                .ToListAsync();

            return View(categories);
        }

        [HttpGet]
        public IActionResult CategoryCreate()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryCreate(WorkCategory category)
        {
            if (!ModelState.IsValid) { return View(); }
            bool checkExistence = await _context.WorkCategories.AnyAsync(c => c.Name.ToLower().Trim() == category.Name.ToLower().Trim());
            if (checkExistence)
            {
                ModelState.AddModelError("Name", "Already exitsts!");
                return View();
            }
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Categories");
        }

        //---------------------------------------------------------  products

        public async Task<IActionResult> Products()
        {
            List<WorkProduct> products = await _context.WorkProducts
                .Include(c => c.Category)
                .OrderBy(x => x.Id)
                .ToListAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProductCreate(WorkProduct product)
        {
            if (!ModelState.IsValid)
            {   
                return View();
            }
            
            return Json(product);
        }

    }
}
