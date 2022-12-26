using Microsoft.AspNetCore.Mvc;

namespace hometask_17.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
