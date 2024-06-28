using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Models;
using System.Net.Http;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardLast5ProductComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apisettings;
        public _DashboardLast5ProductComponentPartial(IHttpClientFactory httpClientFactory,IOptions<ApiSettings> apisettings)
        {
            _httpClientFactory = httpClientFactory;
            _apisettings = apisettings.Value;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var response = await client.GetAsync("Product/GetAllProduct5Async");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var listvalue = JsonConvert.DeserializeObject<List<ResultLast5ProductDto>>(data);
                return View(listvalue);
            }
            return View();
        }
    }
}
