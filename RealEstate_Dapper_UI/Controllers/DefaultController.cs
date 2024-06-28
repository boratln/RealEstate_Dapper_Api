using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Models;
using System.Net.Http;

namespace RealEstate_Dapper_UI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apisettings;
        public DefaultController(IHttpClientFactory httpClientFactory,IOptions <ApiSettings> apiSettings)
        {
            _httpClientFactory= httpClientFactory;
            _apisettings= apiSettings.Value;
        }
        public async  Task<IActionResult> Index()
        {
			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_apisettings.BaseUrl);
			var responseMessage = await client.GetAsync("Category");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
				return View(values);
			}
			return View();
		}
        [HttpGet]
        public async  Task<PartialViewResult> PartialSearch()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);

            var responseMessage = await client.GetAsync("Category");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return PartialView(values);
            }
            return PartialView();
        }
        [HttpPost]
        public IActionResult PartialSearch(string keyword,int categoryid,string city) {
            TempData["keyword"] = keyword;
            TempData["categoryid"] = categoryid;
            TempData["city"] = city;
            return RedirectToAction("PropertyListWithSearch","Property");
        
        }
    }
}
