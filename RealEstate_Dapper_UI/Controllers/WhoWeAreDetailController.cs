using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDto;
using RealEstate_Dapper_UI.Models;
using System.Configuration;

namespace RealEstate_Dapper_UI.Controllers
{
    public class WhoWeAreDetailController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ApiSettings _apisettings;
        public WhoWeAreDetailController(IHttpClientFactory httpClientFactory,IOptions<ApiSettings> apisettings)
        {
            this.httpClientFactory = httpClientFactory;
            _apisettings = apisettings.Value;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["title"] = "Biz Kimiz Admin Sayfası";
            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var response = await client.GetAsync("WhoWeAreDetail");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<Dtos.WhoWeAreDto.ResultWhoWeAreDetail>>(data);
                return View(json);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateWhoWeAreDetail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAreDetail( CreateWhoWeAreDetailDto whoWeAreDetailDto)
        {
            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var jsondata = JsonConvert.SerializeObject(whoWeAreDetailDto);
            StringContent content = new StringContent(jsondata, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("WhoWeAreDetail", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        public async Task<IActionResult> DeleteWhoWeAreDetail(int id)
        {
            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var responsemessage = await client.DeleteAsync($"WhoWeAreDetail/{id}");
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> UpdateWhoWeAreDetail(int id)
        {
            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var responsemessage = await client.GetAsync($"WhoWeAreDetail/{id}");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateWhoWeAreDetail>(jsondata);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeAreDetail categorydto)
        {
            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var json = JsonConvert.SerializeObject(categorydto);
            StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var responsemessage = await client.PutAsync($"WhoWeAreDetail", content);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
