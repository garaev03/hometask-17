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
                return View();

            if(product.CategoryId== 0 || product.CategoryId==null)
                product.CategoryId = 8;  //8 idli other categoriyasidir
            Guid guid = new Guid();
            string RootPath = _env.WebRootPath;
            string FolderPath = "\\assets\\img\\userImages\\";
            //string FullName = guid + product.FormFiles[0].FileName;
            //string Fullpath = Path.Combine(_env.WebRootPath, FolderPath,FullName);
            //using (FileStream reader=new FileStream("salam","salam"))
            //{

            //}


            return Json(guid);
        }
    }
}
