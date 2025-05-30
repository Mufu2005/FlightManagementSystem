using Microsoft.AspNetCore.Mvc;
using FMS_Front_End.Models;
using System.Net.Http.Json;
using FMS_Front_End.Models;

public class FlightController : Controller
{
    private readonly HttpClient _httpClient;

    public FlightController(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient();
        _httpClient.BaseAddress = new Uri("http://localhost:5001"); // FlightService
    }

    public async Task<IActionResult> Index()
    {
        var flights = await _httpClient.GetFromJsonAsync<List<Flight>>("http://localhost:5057/api/flight");
        return View(flights);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Flight flight)
    {
        var response = await _httpClient.PostAsJsonAsync("http://localhost:5057/api/flight", flight);
        return response.IsSuccessStatusCode ? RedirectToAction("Index") : View(flight);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var flight = await _httpClient.GetFromJsonAsync<Flight>($"http://localhost:5057/api/flight/{id}");
        return View(flight);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Flight flight)
    {
        var response = await _httpClient.PutAsJsonAsync($"http://localhost:5057/api/flight/{flight.Id}", flight);
        return response.IsSuccessStatusCode ? RedirectToAction("Index") : View(flight);
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _httpClient.DeleteAsync($"http://localhost:5057/api/flight/{id}");
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Search(string keyword)
    {
        var allFlights = await _httpClient.GetFromJsonAsync<List<Flight>>("http://localhost:5057/api/flight");
        var result = allFlights
            .Where(f => f.Source.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                        || f.Destination.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
        return View("Index", result);
    }
}