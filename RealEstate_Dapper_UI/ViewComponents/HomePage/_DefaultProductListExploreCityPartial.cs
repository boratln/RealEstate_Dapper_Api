using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.PopularLocationDtos;
using RealEstate_Dapper_UI.Models;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultProductListExploreCityPartial:ViewComponent
    {

        private readonly IHttpClientFactory httpClientFactory;
        private readonly ApiSettings _apisettings;
        public _DefaultProductListExploreCityPartial(IHttpClientFactory httpClientFactory,IOptions<ApiSettings> apisettings)
        {
            this.httpClientFactory = httpClientFactory;
            _apisettings = apisettings.Value;
        }

        public async  Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var responsemessage = await client.GetAsync("PopularLocation");
            if (responsemessage.IsSuccessStatusCode)
            {
                var data= await responsemessage.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<ResultPopularLocationDtos>>(data);
                return View(json);

            }
            return View();
        }
    }
}
