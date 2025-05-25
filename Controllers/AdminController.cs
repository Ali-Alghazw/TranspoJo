using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TranspoJo.DTOs;

namespace TranspoJo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Net.Http;
    using System.Net.Http.Json;
    using TranspoJo.DTOs; // adjust namespace
    using Microsoft.Extensions.Configuration;

    public class AdminController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public AdminController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _apiBaseUrl = configuration["ApiBaseUrlAdmin"];
        }

        public async Task<IActionResult> Dashboard()
        {
            var dashboardData = await _httpClient.GetFromJsonAsync<AdminDashboardDto>($"{_apiBaseUrl}/dashboard");
            return View(dashboardData);
        }
    }

}



