using Microsoft.AspNetCore.Mvc;

namespace TranspoJo.Controllers
{
    public class PublicController : Controller
    {
        public IActionResult Public()
        {
            return View();
        }
    }
}
