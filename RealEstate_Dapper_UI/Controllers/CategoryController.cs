using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using RealEstate_Dapper_UI.Models;

namespace RealEstate_Dapper_UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ApiSettings _apisettings;
        public CategoryController(IHttpClientFactory httpClientFactory,IOptions <ApiSettings> apiSettings)
        {
            this.httpClientFactory = httpClientFactory;
            _apisettings = apiSettings.Value;
        }
        public async  Task<IActionResult> Index()
        {
            ViewData["title"] = "Kategori Sayfası";
            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var response = await client.GetAsync("Category");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<Dtos.CategoryDtos.ResultCategoryDto>>(data);
                return View(json);
            }
            return View();
        }

        [HttpGet("CreateCategory")]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto categorydto)
        {
            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var jsondata = JsonConvert.SerializeObject(categorydto);
            StringContent content=new StringContent(jsondata,System.Text.Encoding.UTF8,"application/json");
            var response = await client.PostAsync("Category", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client= httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var responsemessage = await client.DeleteAsync($"Category/{id}");
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var responsemessage = await client.GetAsync($"Category/{id}");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var value =  JsonConvert.DeserializeObject<UpdateCategoryDto>(jsondata);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto categorydto)
        {
            var client = httpClientFactory.CreateClient();
                        client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var json=JsonConvert.SerializeObject(categorydto);
            StringContent content=new StringContent(json,System.Text.Encoding.UTF8,"application/json");
            var responsemessage = await client.PutAsync("Category",content);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
