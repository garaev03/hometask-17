using hometask_17.DAL.Models;
using hometask_17.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hometask_17.Controllers
{
    public class WorkController : Controller
    {
        private readonly PurpleBuzzDbContext? _context=new();
        //public WorkController(PurpleBuzzDbContext? context)
        //{
        //    _context = context;
        //}

        public IActionResult Index()
        {
            WorkMV workMV = new WorkMV()
            {
                categories=_context.WorkCategories.ToList(),
                products=_context.WorkProducts.ToList(),
                productCategories=_context.WorkProductCategories
                .Include(x => x.product)
                .Include(x => x.category)
                .OrderByDescending(x => x.Id)
                .ToList()

            };

            return View(workMV);
        }
    }
}
