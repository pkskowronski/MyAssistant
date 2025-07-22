using Microsoft.AspNetCore.Mvc;

namespace MyAssistant.Controllers
{
    public class PlaygroundController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
