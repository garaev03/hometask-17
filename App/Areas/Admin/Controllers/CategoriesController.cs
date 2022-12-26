using hometask_17.DAL.Models;
using hometask_17.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hometask_17.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly PurpleBuzzDbContext _context;

        public CategoriesController(PurpleBuzzDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Main()
        {
            List<WorkCategory> categories = await _context.WorkCategories
                .Include(x => x.Products)
                .OrderBy(c => c.Id)
                .ToListAsync();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkCategory category)
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
            return RedirectToAction("Main");
        }

        public IActionResult Update(int id)
        {
            WorkCategory category = _context.WorkCategories.Find(id);

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Update(WorkCategory editedCategory)
        {
            if(!ModelState.IsValid) { return View();}
                
            WorkCategory category = _context.WorkCategories.Find(editedCategory.Id);

            category.Name = editedCategory.Name;

            await _context.SaveChangesAsync();

            return RedirectToAction("Main");
        }

        public async Task<IActionResult> Delete(int id)
        {
            WorkCategory category = _context.WorkCategories.Find(id);

            category.isDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction("Main");
        }

        public async Task<IActionResult> Recover(int id)
        {
            WorkCategory category = _context.WorkCategories.Find(id);

            category.isDeleted = false;

            await _context.SaveChangesAsync();

            return RedirectToAction("Main");
        }
    }
}
