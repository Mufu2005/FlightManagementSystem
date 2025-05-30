using FMS_Front_End.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace FMS_Front_End.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private HttpClient _client => CreateClientWithToken();

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient CreateClientWithToken()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("http://localhost:5287/api/");

            var token = HttpContext?.Session?.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return client;
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("JWToken")))
                return RedirectToAction("Profile");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var response = await _client.PostAsJsonAsync("auth/register", model);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Login");
            ModelState.AddModelError("", "Registration failed");
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("JWToken")))
                return RedirectToAction("Profile");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("http://localhost:5287/api/");

            var response = await client.PostAsJsonAsync("auth/login", model);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError("", $"Login failed {error}");
                return View(model);
            }

            var content = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
            HttpContext.Session.SetString("JWToken", content["token"]);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("JWToken");
            return RedirectToAction("Login");
        }   

        // Example: access protected resource
        public async Task<IActionResult> Profile()
        {
            var response = await _client.GetAsync("auth/profile"); // this must be a protected endpoint
            if (!response.IsSuccessStatusCode)
                return RedirectToAction("Login");

            var data = await response.Content.ReadAsStringAsync(); // replace with actual deserialization
            ViewBag.Profile = data;
            return View();
        }
    }
}
