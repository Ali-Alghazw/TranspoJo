using Microsoft.AspNetCore.Mvc;

namespace TranspoJo.Controllers
{
    public class RentalController : Controller
    {
        public IActionResult Rental()
        {
            return View();
        }

        public IActionResult Dynamic()
        {
            return View();
        }
    }
}
