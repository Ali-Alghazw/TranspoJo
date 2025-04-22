using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TranspoJo.Models;

namespace TranspoJo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult home()
    {
        return View();
    }
    public IActionResult login()
    {
        return View();
    }
    public IActionResult pick()
    {
        return View();
    }
    public IActionResult route()
    {
        return View();
    }
    public IActionResult Destination()
    {
        return View();
    }
    
    public IActionResult Privacy()
    {
        return View();
    }
	[HttpPost]
	public IActionResult SubmitForm(Coordinate model)
	{
		return RedirectToAction("Destination", model);
	}
	[HttpGet]
	public IActionResult Destination(Coordinate model)
	{
		return View(model);

	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
