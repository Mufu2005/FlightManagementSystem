using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using FMS_Front_End.Models;
using Microsoft.AspNetCore.Mvc;

namespace FMS_Front_End.Controllers
{
    public class BookingController : Controller
    {
        private readonly HttpClient _httpClient;

        public BookingController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5002/"); // BookingService base URL
        }

        // GET: /Booking
        public async Task<IActionResult> Index()
        {
            var bookings = await _httpClient.GetFromJsonAsync<List<Booking>>("http://localhost:5138/api/bookings");
            return View(bookings);
        }

        // GET: /Booking/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Booking/Create
        [HttpPost]
        public async Task<IActionResult> Create(Booking booking)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5138/api/bookings", booking);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));
            return View(booking);
        }

        // GET: /Booking/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var booking = await _httpClient.GetFromJsonAsync<Booking>($"http://localhost:5138/api/bookings/{id}");
            return View(booking);
        }

        // POST: /Booking/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Booking booking)
        {
            var response = await _httpClient.PutAsJsonAsync($"http://localhost:5138/api/bookings/{id}", booking);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Booking/Delete/5s
        public async Task<IActionResult> Delete(int id)
        {
            var booking = await _httpClient.GetFromJsonAsync<Booking>($"http://localhost:5138/api/bookings/{id}");
            return View(booking);
        }

        // POST: /Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _httpClient.DeleteAsync($"http://localhost:5138/api/bookings/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
