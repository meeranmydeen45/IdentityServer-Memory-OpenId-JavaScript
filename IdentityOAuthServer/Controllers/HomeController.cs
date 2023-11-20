using Microsoft.AspNetCore.Mvc;

namespace IdentityOAuthServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        [HttpGet]
        public IActionResult Index()
        {
            string name = "I am Meeran!";
            return View("Index", name);
        }

    }
}