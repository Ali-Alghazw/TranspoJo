using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using TranspoJo.DTOs;

namespace TranspoJo.Controllers
{
    [Authorize(Roles = "Admin")]  // Protect MVC controller with Admin role
    public class BusStationsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrlbusstation;

        public BusStationsController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _apiBaseUrlbusstation = configuration["ApiBaseUrlbusstation"];
        }

        // Helper method to set the Authorization header with bearer token
        private void AddAuthToken()
        {
            var token = HttpContext.Session.GetString("AuthToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<IActionResult> Index()
        {
            AddAuthToken();

            var stations = await _httpClient.GetFromJsonAsync<List<BusStationDto>>($"{_apiBaseUrlbusstation}/get-all");
            return View(stations);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BusStationDto dto)
        {
            AddAuthToken();

            var response = await _httpClient.PostAsJsonAsync($"{_apiBaseUrlbusstation}/create", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(dto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            AddAuthToken();

            var dto = await _httpClient.GetFromJsonAsync<BusStationDto>($"{_apiBaseUrlbusstation}/get-by-id/{id}");
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BusStationDto dto)
        {
            AddAuthToken();

            var response = await _httpClient.PutAsJsonAsync($"{_apiBaseUrlbusstation}/{dto.Id}", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(dto);
        }
    }
}
