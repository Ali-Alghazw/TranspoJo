using Microsoft.AspNetCore.Mvc;

namespace TranspoJo.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Net.Http;
    using System.Net.Http.Json;
    using TranspoJo.DTOs;

    public class BusStationsController : Controller
    {

        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrlbusstation;

        public BusStationsController(IHttpClientFactory httpClientFactory , IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _apiBaseUrlbusstation = configuration["ApiBaseUrlbusstation"];

        }

        public async Task<IActionResult> Index()
        {
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
            var response = await _httpClient.PostAsJsonAsync($"{_apiBaseUrlbusstation}/create", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));
            return View(dto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _httpClient.GetFromJsonAsync<BusStationDto>($"{_apiBaseUrlbusstation}/get-by-id/{id}");
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BusStationDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_apiBaseUrlbusstation}/{dto.Id}", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));
            return View(dto);
        }



    }

}
