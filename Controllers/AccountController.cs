using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TranspoJo.DTOs;

namespace TranspoJo.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiBaseUrl;
        public AccountController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _apiBaseUrl = configuration["ApiBaseUrl"];
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var client = _httpClientFactory.CreateClient();
            var apiUrl = $"{_apiBaseUrl}/api/auth/login";

            var response = await client.PostAsJsonAsync(apiUrl, new { model.Email, model.Password });

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.LoginError = "Invalid email or password.";
                return View(model);
            }

            var loginResult = await response.Content.ReadFromJsonAsync<LoginResponseDto>();

            if (!loginResult.IsAdmin)
            {
                ViewBag.LoginError = "Access denied. Admins only.";
                return View(model);
            }

            // ✅ Store JWT token in session
            HttpContext.Session.SetString("AuthToken", loginResult.Token);

            // ✅ Sign in using cookie authentication
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, loginResult.Email),
        new Claim(ClaimTypes.Role, "Admin")
    };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Dashboard", "Admin");
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Pick", "Home");
        }

    }
}
