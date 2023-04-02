using Microsoft.AspNetCore.Mvc;

namespace House.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
