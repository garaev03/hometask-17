using Microsoft.AspNetCore.Mvc;

namespace hometask_17.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
