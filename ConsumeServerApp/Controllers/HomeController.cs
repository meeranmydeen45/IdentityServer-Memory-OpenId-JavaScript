using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeServerApp.Controllers.Home
{
    public class HomeController : ControllerBase
    {

        public IActionResult Index()
        {
            return Ok("I am Consume Server Page!!");
        }

        [Authorize]
        public IActionResult Secret()
        {
            return Ok("I am Secret Resource you can reache after consume Identity Server!!");
        }
    }
}
