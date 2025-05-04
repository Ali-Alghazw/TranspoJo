using Microsoft.AspNetCore.Mvc;

namespace TranspoJo.Controllers
{
    public class RentalCarJoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dynamic()
        {
            return View();
        }
    }
}
