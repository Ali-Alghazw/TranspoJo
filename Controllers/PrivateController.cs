using Microsoft.AspNetCore.Mvc;

namespace TranspoJo.Controllers
{
    public class PrivateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
