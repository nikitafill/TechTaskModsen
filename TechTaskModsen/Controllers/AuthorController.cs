using Microsoft.AspNetCore.Mvc;

namespace TechTaskModsen.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
