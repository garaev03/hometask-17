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
               .Include(c => c.Category)
               .Include(i => i.Images)
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
        public async Task<IActionResult> Create(WorkProduct product)
        {
            if (!ModelState.IsValid)
                return View();

            if (product.CategoryId == 0)
                product.CategoryId = 8;  //8 idli other categoriyasidir

            string FolderPath = "assets/img/userImages";

            foreach (var formFile in product.FormFiles)
            {
                string FullName = Guid.NewGuid() + "-" + formFile.FileName;
                string Fullpath = Path.Combine(_env.WebRootPath,FolderPath, FullName);
                using (FileStream reader = new FileStream(Fullpath, FileMode.Create))
                {
                    formFile.CopyTo(reader);
                    WorkImage image = new()
                    {
                        Path = FullName,
                        Product = product,
                        isMain = false
                    };
                    if (product.FormFiles.IndexOf(formFile)==0)
                        image.isMain = true;

                    await _context.WorkImages.AddAsync(image);
                };
            }
            await _context.WorkProducts.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Main");
        }
    }
}
