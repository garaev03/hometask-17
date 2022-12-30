using Microsoft.AspNetCore.Mvc;

namespace hometask_17.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error404()
        {
            return View();
        }
    }
}
