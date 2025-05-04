using Microsoft.AspNetCore.Mvc;

namespace TranspoJo.Controllers
{
    public class PublicTranspController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
