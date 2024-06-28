using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RealEstate_Dapper_UI.Models;
using RealEstate_Dapper_UI.Services;
using System.Net.Http;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashboardStatisticComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService LoginService;
        private readonly ApiSettings _apisettings;
        public _EstateAgentDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory,ILoginService login,IOptions<ApiSettings> apisettings)
        {
            _httpClientFactory = httpClientFactory;
            LoginService = login;
            _apisettings = apisettings.Value;
        }
        public async Task <IViewComponentResult> InvokeAsync()
        {
            var id = LoginService.GetUserId;
            #region Statistics1 - ToplamİlanSayısı
            var client1 = _httpClientFactory.CreateClient();
            client1.BaseAddress = new Uri(_apisettings.BaseUrl);

            var responseMessage1 = await client1.GetAsync("EstateAgentDashboard/AllProductCount");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData1;
            #endregion
            #region Statistics2 -EmlakçıyaGöreİlanSayısı
            var client2 = _httpClientFactory.CreateClient();
            client2.BaseAddress = new Uri(_apisettings.BaseUrl);

            var responseMessage2 = await client2.GetAsync($"EstateAgentDashboard/ProductCountByEmployeeId/{id}");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.productcountbyemployee = jsonData2;
            #endregion
            #region Statistics3-EmlakçınınGeçerliİlanSayısı
            var client3 = _httpClientFactory.CreateClient();
            client3.BaseAddress = new Uri(_apisettings.BaseUrl);

            var responseMessage3 = await client3.GetAsync($"EstateAgentDashboard/ProductCountByStatusTrue/{id}");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.productcountstatustrue = jsonData3;
            #endregion
            #region Statistics4- EmlakçınınGeçersizİlanSayısı
            var client4 = _httpClientFactory.CreateClient();
            client4.BaseAddress = new Uri(_apisettings.BaseUrl);

            var responseMessage4 = await client4.GetAsync($"EstateAgentDashboard/ProductCountByStatusFalse/{id}");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.productcountstatusfalse = jsonData4;
            #endregion
            return View();
        }
    }
}
