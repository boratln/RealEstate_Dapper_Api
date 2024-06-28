using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ChartDto;
using RealEstate_Dapper_UI.Models;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashbordChartComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apisettings;
        public _EstateAgentDashbordChartComponentPartial(IHttpClientFactory httpClientFactory,IOptions<ApiSettings> apisettings)
        {
            _httpClientFactory = httpClientFactory;
            _apisettings = apisettings.Value;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);

            var response = await client.GetAsync("EstateAgentDashboard/chart");
            if (response.IsSuccessStatusCode){
                var data = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<ResultChartDto>>(data);
                return View(json);
            }
            return View();
        }
    }
}
