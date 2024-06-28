using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Services;
using RealEstate_Dapper_UI.Dtos.MessageDtos;
using RealEstate_Dapper_UI.Models;
using Microsoft.Extensions.Options;
namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent.EstateAgentNavbar
{
    public class _EstateAgentNavbarMessageComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService login;
        private readonly ApiSettings _apisettings;
        public _EstateAgentNavbarMessageComponentPartial(IHttpClientFactory httpClientFactory, ILoginService login,IOptions<ApiSettings> apisettings)
        {
            _httpClientFactory = httpClientFactory;
            this.login = login;
            _apisettings = apisettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = login.GetUserId;
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var response = await client.GetAsync($"Message/Get3MessageListbyreceiver/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<ResultInboxMessageDto>>(data);
                return View(json);
            }
            return View();
        }
    }
}
