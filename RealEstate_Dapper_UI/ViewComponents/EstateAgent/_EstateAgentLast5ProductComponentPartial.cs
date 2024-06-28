using Elfie.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Models;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentLast5ProductComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService loginService;
        private readonly ApiSettings _apisettings;
        public _EstateAgentLast5ProductComponentPartial(IHttpClientFactory httpClientFactory,ILoginService login,IOptions<ApiSettings> apisettings)
        {
            _httpClientFactory = httpClientFactory;
            loginService = login;
            _apisettings = apisettings.Value;
        }
       public async  Task<IViewComponentResult> InvokeAsync()
        {
            var id=loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            
            var response = await client.GetAsync($"https://localhost:7093/api/EstateAgentDashboard/last5product/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<ResultLast5ProductDto>>(data);
                return View(json);
            }
            return View();
        }
    }
}
