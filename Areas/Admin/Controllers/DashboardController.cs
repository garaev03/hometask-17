using Microsoft.AspNetCore.Mvc;

namespace hometask_17.Areas.Admin.Controllers
{   
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
