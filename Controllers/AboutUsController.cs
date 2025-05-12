using Microsoft.AspNetCore.Mvc;

namespace TranspoJo.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
