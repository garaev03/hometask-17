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
        private readonly IWebHostEnvironment _env;

        public ProductsController(PurpleBuzzDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Main()
        {
            List<WorkProduct> products = await _context.WorkProducts
               .Where(p => !p.isDeleted)
               .Include(c => c.Category)
               .Include(i => i.Images)
               .OrderBy(x => x.Id)
               .ToListAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Categories"] = _context.WorkCategories.Where(x => !x.isDeleted).ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(WorkProduct product)
        {
            ViewData["Categories"] = _context.WorkCategories.ToList();
            if (!ModelState.IsValid)
                return View(product);

            string error = CheckFile(product);

            if (error != null)
            {
                ModelState.AddModelError("FormFiles", error);
                return View(product);
            }

            var category = _context.WorkCategories.Where(x => !x.isDeleted).FirstOrDefault(x => x.Name == product.Category.Name);
            if (category == null)
            {
                ModelState.AddModelError("Category.Name", "Invalid category name");
                return View(product);
            }
            product.Category = category;

            string FolderPath = "assets/img/Product Images";
            CreateImage(product, FolderPath, _context);

            await _context.WorkProducts.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Main");
        }

        public IActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(WorkProduct editedProduct)
        {
            return View();
        }

        public async Task<bool> Delete(int id)
        {
            var product = await _context.WorkProducts.FindAsync(id);
            if (product == null)
                return false;           
                product.isDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }
        private async void CreateImage(WorkProduct product, string FolderPath, PurpleBuzzDbContext _context)
        {

            foreach (var formFile in product.FormFiles)
            {
                string FullName = Guid.NewGuid() + "-" + formFile.FileName;
                string Fullpath = Path.Combine(_env.WebRootPath, FolderPath, FullName);

                using (FileStream reader = new FileStream(Fullpath, FileMode.Create))
                {
                    formFile.CopyTo(reader);
                };

                WorkImage image = new()
                {
                    Path = FullName,
                    Product = product,
                    isMain = false
                };
                if (product.FormFiles.IndexOf(formFile) == 0)
                    image.isMain = true;

                await _context.WorkImages.AddAsync(image);
            }
        }
        private string CheckFile(WorkProduct product)
        {
            string? error = null;
            if (product.FormFiles == null)
            {
                error = "Please enter image(s)...";
                return error;
            }

            foreach (var formFile in product.FormFiles)
            {
                if (!formFile.ContentType.Contains("image"))
                {
                    error = "Please choose only images...";
                    return error;
                }
                if (formFile.Length / 1024 / 1024 > 2)
                {
                    error = "Choose images less than 2Mb...";
                    return error;
                }
            }
            return error;
        }
    }
}
