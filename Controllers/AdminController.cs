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
    using System.Net;


    [Authorize(Roles = "Admin")]

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
            var token = HttpContext.Session.GetString("AuthToken");

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5139/api/admin/dashboard");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.SendAsync(request);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    HttpContext.Session.Remove("AuthToken");
                    return RedirectToAction("Login", "Account");
                }

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.Error = "Failed to load dashboard. Status code: " + response.StatusCode;
                    return View(new AdminDashboardDto());
                }

                var dashboardData = await response.Content.ReadFromJsonAsync<AdminDashboardDto>();

                return View(dashboardData);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Unexpected error: " + ex.Message;
                return View(new AdminDashboardDto());
            }
        }


}

}



