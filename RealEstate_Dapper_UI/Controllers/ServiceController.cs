using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDto;
using RealEstate_Dapper_UI.Models;
using System.Net.Http;

namespace RealEstate_Dapper_UI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpclientfactory;
        private readonly ApiSettings _apisettings;
        public ServiceController(IHttpClientFactory httpclientfactory,IOptions<ApiSettings> apisettings)
        {
            _httpclientfactory = httpclientfactory;
            _apisettings = apisettings.Value;
        }
        public async  Task<IActionResult> Index()
        {
            ViewData["title"] = "Hizmetler Admin Sayfası";
            var client = _httpclientfactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);

            var response = await client.GetAsync("Service");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<Dtos.WhoWeAreDto.ResultServiceDto>>(data);
                return View(json);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto serviceDto)
        {
            var client = _httpclientfactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var jsondata = JsonConvert.SerializeObject(serviceDto);
            StringContent content = new StringContent(jsondata, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("Service", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

   
        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var client = _httpclientfactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var responsemessage = await client.GetAsync($"Service/{id}");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateServiceDto>(jsondata);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateServiceDto serviceDto)
        {
            var client = _httpclientfactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var json = JsonConvert.SerializeObject(serviceDto);
            StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var responsemessage = await client.PutAsync($"Service", content);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
