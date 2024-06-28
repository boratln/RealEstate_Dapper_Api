using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductImageDtos;
using RealEstate_Dapper_UI.Models;

namespace RealEstate_Dapper_UI.ViewComponents.PropertyPage
{
    public class _PropertyPageImageByProductIdComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ApiSettings _apisettings;
        public _PropertyPageImageByProductIdComponentPartial(IHttpClientFactory httpClientFactory,IOptions<ApiSettings> apisettings)
        {
            this.httpClientFactory = httpClientFactory;
            _apisettings = apisettings.Value;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
           
            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var response = await client.GetAsync($"ProductImage/GetProductImageByProductId/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<ResultProductImageByProductIdDto>>(data);
                return View(json);
            }
            return View();
        }
    }
}
