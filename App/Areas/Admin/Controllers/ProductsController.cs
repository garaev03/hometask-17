using hometask_17.DAL.Models;
using hometask_17.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hometask_17.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly PurpleBuzzDbContext _context;

        public ProductsController(PurpleBuzzDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Main()
        {
            List<WorkProduct> products = await _context.WorkProducts
               .Include(c => c.Category)
               .Include(i=>i.Images)
               .OrderBy(x => x.Id)
               .ToListAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(WorkProduct product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            return Json(product.Name);
        }
    }
}
