using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.EmployeeDtos;
using RealEstate_Dapper_UI.Models;
using System.Net.Http;

namespace RealEstate_Dapper_UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apisettings;
        public EmployeeController(IHttpClientFactory httpClientFactory,IOptions<ApiSettings> apisettings)
        {
            _httpClientFactory = httpClientFactory;
            _apisettings= apisettings.Value;
        }
        [Authorize]
        public async Task <IActionResult> Index()
        {
            var user = User.Claims;
            var token=User.Claims.FirstOrDefault(x=>x.Type== "realestatetoken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_apisettings.BaseUrl);
                var response = await client.GetAsync("Employee");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var json = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(data);
                    return View(json);
                }
            }
         
            return View();
        }
        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto employeeDto)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var jsondata = JsonConvert.SerializeObject(employeeDto);
            StringContent content = new StringContent(jsondata, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("Employee", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var responsemessage = await client.GetAsync($"Employee/{id}");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateEmployeeDto>(jsondata);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto employeeDto)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var json = JsonConvert.SerializeObject(employeeDto);
            StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var responsemessage = await client.PutAsync("Employee", content);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
