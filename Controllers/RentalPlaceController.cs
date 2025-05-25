using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using TranspoJo.DTOs;

namespace TranspoJo.Controllers
    {

        public class RentalPlacesController : Controller
        {
            private readonly HttpClient _httpClient;
            private readonly string _apiBaseUrlRentalPlace;

            public RentalPlacesController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
            {
                _httpClient = httpClientFactory.CreateClient();
            _apiBaseUrlRentalPlace = configuration["ApiBaseUrlRentalPlace"];
        }

        public async Task<IActionResult> Index()
            {
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
            var response = await _httpClient.PostAsJsonAsync($"{_apiBaseUrlRentalPlace}", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(dto);
        }


        public async Task<IActionResult> Edit(string id)
            {
                var dto = await _httpClient.GetFromJsonAsync<RentalPlaceDTO>($"{_apiBaseUrlRentalPlace}/{id}");
                return View(dto);
            }

            [HttpPost]
            public async Task<IActionResult> Edit(RentalPlaceDTO dto)
            {
                var response = await _httpClient.PutAsJsonAsync($"{_apiBaseUrlRentalPlace}/{dto.Id}", dto);
                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));
                return View(dto);
            }
        }
    }


