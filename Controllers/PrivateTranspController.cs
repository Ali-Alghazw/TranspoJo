using Microsoft.AspNetCore.Mvc;

namespace TranspoJo.Controllers
{
    public class PrivateTranspController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
