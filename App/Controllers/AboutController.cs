using Microsoft.AspNetCore.Mvc;

namespace hometask_17.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
