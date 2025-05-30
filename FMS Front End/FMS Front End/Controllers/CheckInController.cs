using FMS_Front_End.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;


namespace FMS_Front_End.Controllers
{
    public class CheckInController : Controller
    {
        private readonly HttpClient _httpClient;

        public CheckInController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var checkIns = await _httpClient.GetFromJsonAsync<List<CheckIn>>("http://localhost:5032/api/CheckIn");
            return View(checkIns);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CheckIn checkIn)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5032/api/CheckIn", checkIn);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View(checkIn);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var checkIn = await _httpClient.GetFromJsonAsync<CheckIn>($"http://localhost:5032/api/CheckIn/{id}");
            return View(checkIn);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CheckIn checkIn)
        {
            var response = await _httpClient.PutAsJsonAsync($"http://localhost:5032/api/CheckIn/{checkIn.Id}", checkIn);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View(checkIn);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _httpClient.DeleteAsync($"http://localhost:5032/api/CheckIn/{id}");
            return RedirectToAction("Index");
        }
    }
}
