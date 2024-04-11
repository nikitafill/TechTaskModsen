using Microsoft.AspNetCore.Mvc;

namespace TechTaskModsen.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
