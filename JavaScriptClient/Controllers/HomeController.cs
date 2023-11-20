using Microsoft.AspNetCore.Mvc;

namespace JavaScriptClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SigIn()
        {
            return View();
        }
    }
}
