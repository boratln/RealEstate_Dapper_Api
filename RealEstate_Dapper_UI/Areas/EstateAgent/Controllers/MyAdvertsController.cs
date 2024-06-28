using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Services;
using System.Net.Http;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    public class MyAdvertsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginservice;
        public MyAdvertsController(IHttpClientFactory httpClientFactory,ILoginService loginservice)
        {
            _httpClientFactory = httpClientFactory;
            _loginservice = loginservice;
        }
        [Authorize]
        public async  Task<IActionResult> ActiveAdverts()
        {
            var id = _loginservice.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7093/api/Product/ProductAdvertsListByEmployeeIdByTrue/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<RealEstate_Dapper_UI.Areas.EstateAgent.Models.EstateAgentAdvertDto.ResultAdvertDto>>(data);
                return View(json);
            }
            return View();
        }
        public async Task<IActionResult> InactiveAdverts()
        {
            var id = _loginservice.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7093/api/Product/ProductAdvertsListByEmployeeIdByFalse/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<RealEstate_Dapper_UI.Areas.EstateAgent.Models.EstateAgentAdvertDto.ResultAdvertDto>>(data);
                return View(json);
            }
            return View();
        }
        [HttpGet]
        public async Task <IActionResult> CreateAdvert()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7093/api/Category");

            var jsondata = await response.Content.ReadAsStringAsync();
            var categoryvalues = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsondata);
            List<SelectListItem> selecteditem = (from x in categoryvalues.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }
                                               ).ToList();
            ViewBag.v = selecteditem;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdvert(CreateProductDto productdto)
        {
            var id = _loginservice.GetUserId;
            productdto.EmployeeId = int.Parse(id);
            productdto.DealOfTheDay = false;
            productdto.AdvertisementDate = DateTime.Now;
            productdto.ProductStatus = true;

            var client= _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(productdto);
            var content = new StringContent(jsondata, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7093/api/Product/CreateProduct", content);
            if (response.IsSuccessStatusCode)
            {
                return View("/EstateAgent/MyAdverts/ActiveAdverts");
            }
            return View();
        }
    }
}
