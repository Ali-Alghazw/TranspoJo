using Microsoft.AspNetCore.Mvc;

namespace TranspoJo.Controllers
{
    public class PrivateTranspoJoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
