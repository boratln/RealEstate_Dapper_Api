using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentSidebarComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
      
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
