using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.BottomGridDtos;
using RealEstate_Dapper_UI.Models;

namespace RealEstate_Dapper_UI.Controllers
{
    public class BottomGridController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ApiSettings _apisettings;
        public BottomGridController(IHttpClientFactory httpClientFactory,IOptions<ApiSettings> apisettings)
        {
            this.httpClientFactory = httpClientFactory;
            _apisettings = apisettings.Value;
        }
        public async Task <IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var response = await client.GetAsync("BottomGrid");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<ResultBottomGrid>>(data);
                return View(json);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateBottomGrid()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBottomGrid(CreateBottomGrid bottomGriddto)
        {
            var client=httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var jsondata = JsonConvert.SerializeObject(bottomGriddto);
            var content = new StringContent(jsondata, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("BottomGrid", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBottomGrid(int id)
        {
            var client=httpClientFactory.CreateClient();
            client.BaseAddress=new Uri(_apisettings.BaseUrl);
            var response = await client.GetAsync($"BottomGrid/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data =await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<UpdateBottomGrid>(data);
                return View(json);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBottomGrid(UpdateBottomGrid bottomGriddto)
        {
            var client=httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var jsondata =JsonConvert.SerializeObject(bottomGriddto);
            var content = new StringContent(jsondata, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync("BottomGrid", content);
            if (response.IsSuccessStatusCode) {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
