using Microsoft.AspNetCore.Mvc;

namespace TranspoJo.Controllers
{
    public class PublicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
