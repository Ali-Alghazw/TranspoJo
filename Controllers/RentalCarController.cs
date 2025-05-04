using Microsoft.AspNetCore.Mvc;

namespace TranspoJo.Controllers
{
    public class RentalCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
