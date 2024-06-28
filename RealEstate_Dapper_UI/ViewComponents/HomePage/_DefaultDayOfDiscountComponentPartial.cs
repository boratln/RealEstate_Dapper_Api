using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Models;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultDayOfDiscountComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apisettings;
        public _DefaultDayOfDiscountComponentPartial(IHttpClientFactory httpClientFactory,IOptions<ApiSettings> apisettings)
        {
            _httpClientFactory = httpClientFactory;
            _apisettings = apisettings.Value;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var response = await client.GetAsync("Product/GetAllProduct3Async");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<ResultLast3ProductWithCategoryDto>>(data);
                return View(json);
            }
            return View();
        }
    }
}
