using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RealEstate_Dapper_UI.Models;
using System.Net.Http;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardStatistictsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apisettings;
        public _DashboardStatistictsComponentPartial(IHttpClientFactory httpClientFactory,IOptions<ApiSettings> apisettings)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async  Task<IViewComponentResult> InvokeAsync()
        {
            #region Statistics1 - ToplamİlanSayısı
            var client1 = _httpClientFactory.CreateClient();
            client1.BaseAddress = new Uri(_apisettings.BaseUrl);
            var responseMessage1 = await client1.GetAsync("Statistics/ProductCount");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData1;
            #endregion
            #region Statistics2 -EnBaşarılıPersonel
            var client2 = _httpClientFactory.CreateClient();
            client2.BaseAddress = new Uri(_apisettings.BaseUrl);

            var responseMessage2 = await client2.GetAsync("Statistics/EmployeeNameByMaxProductCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.employeeNameByMaxProductCount = jsonData2;
            #endregion
            #region Statistics3-İlandakiŞehirSayıları
            var client3 = _httpClientFactory.CreateClient();
            client3.BaseAddress = new Uri(_apisettings.BaseUrl);

            var responseMessage3 = await client3.GetAsync("Statistics/DifferentCityCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.differentCityCount = jsonData3;
            #endregion
            #region Statistics4- OrtalamaaKira
            var client4 = _httpClientFactory.CreateClient();
            client4.BaseAddress = new Uri(_apisettings.BaseUrl);

            var responseMessage4 = await client4.GetAsync("Statistics/AverageProductPriceByRent");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.averageProductPriceByRent = jsonData4;
            #endregion
            return View();
        }
    }
}
