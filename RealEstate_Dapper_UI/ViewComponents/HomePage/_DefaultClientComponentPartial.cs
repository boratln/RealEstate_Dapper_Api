using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.TestimonialDtos;
using RealEstate_Dapper_UI.Models;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultClientComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpclientfactory;
        private readonly ApiSettings _apisettings;
        public _DefaultClientComponentPartial(IHttpClientFactory httpclientfactory,IOptions<ApiSettings> apisettings)
        {
            _httpclientfactory = httpclientfactory;
            _apisettings = apisettings.Value;
        }

        public async  Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpclientfactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var response = await client.GetAsync("Testimonial");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(data);
                return View(json);
            }
            return View();
        }
    }
}
