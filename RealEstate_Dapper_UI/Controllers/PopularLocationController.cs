using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.PopularLocationDtos;
using RealEstate_Dapper_UI.Models;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PopularLocationController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ApiSettings _apisettings;
        public PopularLocationController(IHttpClientFactory httpClientFactory,IOptions<ApiSettings> apisettings)
        {
            this.httpClientFactory = httpClientFactory;
            _apisettings = apisettings.Value;
        }
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);

            var response = await client.GetAsync("PopularLocation");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<ResultPopularLocationDtos>>(data);
                return View(json);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreatePopularLocation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto popularLocationDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(popularLocationDto);
            var content = new StringContent(jsondata, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("PopularLocation", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdatePopularLocation(int id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync($"PopularLocation/Get/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<UpdatePopularLocationDto>(data);
                return View(json);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto popularLocationDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(popularLocationDto);
            var content = new StringContent(jsondata, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync("PopularLocation", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
