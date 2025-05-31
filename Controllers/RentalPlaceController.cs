using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using TranspoJo.DTOs;

namespace TranspoJo.Controllers
{
    [Authorize(Roles = "Admin")]  // Secure access like BusStations
    public class RentalPlacesController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrlRentalPlace;

        public RentalPlacesController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _apiBaseUrlRentalPlace = configuration["ApiBaseUrlRentalPlace"];
        }

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

            var places = await _httpClient.GetFromJsonAsync<List<RentalPlaceDTO>>($"{_apiBaseUrlRentalPlace}");
            return View(places);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RentalPlaceDTO dto)
        {
            AddAuthToken();

            var response = await _httpClient.PostAsJsonAsync($"{_apiBaseUrlRentalPlace}", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(dto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            AddAuthToken();

            var dto = await _httpClient.GetFromJsonAsync<RentalPlaceDTO>($"{_apiBaseUrlRentalPlace}/{id}");
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RentalPlaceDTO dto)
        {
            AddAuthToken();

            var response = await _httpClient.PutAsJsonAsync($"{_apiBaseUrlRentalPlace}/{dto.Id}", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(dto);
        }
    }
}
