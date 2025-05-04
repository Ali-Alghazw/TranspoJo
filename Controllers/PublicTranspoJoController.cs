using Microsoft.AspNetCore.Mvc;

namespace TranspoJo.Controllers
{
    public class PublicTranspoJoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
