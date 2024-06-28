using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Models;

namespace RealEstate_Dapper_UI.Controllers
{
    public class ProductController : Controller
    {
       private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apisettings;
        public ProductController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apisettings)
        {
            _httpClientFactory = httpClientFactory;
            _apisettings = apisettings.Value;
        }
        public async Task <IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var response = await client.GetAsync("Product/ProductListWithCategory");
            if (response.IsSuccessStatusCode)
            {
                var data =  await response.Content.ReadAsStringAsync();
                var listvalue = JsonConvert.DeserializeObject<List<ResultProductDtos>>(data);
                return View(listvalue);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var response = await client.GetAsync("Category");

            var jsondata = await response.Content.ReadAsStringAsync();
            var categoryvalues = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsondata);
            List<SelectListItem> selecteditem = (from x in categoryvalues.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }
                                               ).ToList();
            ViewBag.value=selecteditem;
            return View();
        }

        public async Task<IActionResult> DealOfTheDayStatusChangeToTrue(int id)
        {
            var client= _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var response = await client.GetAsync($"Product/DealOfTheDayStatusChangeToTrue/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DealOfTheDayStatusChangeToFalse(int id)
        {
           
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var response = await client.GetAsync($"Product/DealOfTheDayStatusChangeToFalse/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultProductDtos>(data);
               
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
