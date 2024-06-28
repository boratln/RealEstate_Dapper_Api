using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDto;
using RealEstate_Dapper_UI.Models;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _WhoWeAreComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apisettings;
        public _WhoWeAreComponentPartial(IHttpClientFactory httpClientFactory,IOptions<ApiSettings> apisettings)
        {
            _httpClientFactory = httpClientFactory;
            _apisettings = apisettings.Value;
        }
        public async Task <IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var responseMessage = await client.GetAsync("WhoWeAreDetail");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata=await responseMessage.Content.ReadAsStringAsync();
                var value =  JsonConvert.DeserializeObject<List<ResultWhoWeAreDetail>>(jsondata);
                ViewBag.title = value.Select(x => x.Title).FirstOrDefault();
                ViewBag.subtitle = value.Select(x => x.SubTitle).FirstOrDefault();
                ViewBag.description1 = value.Select(x => x.Description1).FirstOrDefault();
                ViewBag.description2 = value.Select(x => x.Description2).FirstOrDefault();

            }

            var client2 = _httpClientFactory.CreateClient();
            client2.BaseAddress = new Uri(_apisettings.BaseUrl);

            var responsemessage2 = await client2.GetAsync("Service");
            if (responsemessage2.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage2.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsondata);
                return View(value.ToList()); 
            }
            return View();
        }
    }
}
