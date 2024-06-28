using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Dtos.LoginDtos;
using RealEstate_Dapper_UI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;


namespace RealEstate_Dapper_UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apisettings;
        public LoginController(IHttpClientFactory httpClientFactory,IOptions<ApiSettings> apisettings)
        {
            _httpClientFactory = httpClientFactory;
            _apisettings = apisettings.Value;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Index(CreateLoginDto logindto)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);

            var content = new StringContent(JsonSerializer.Serialize(logindto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("Login", content);
            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsondata, new JsonSerializerOptions
                {
                    PropertyNamingPolicy=JsonNamingPolicy.CamelCase
                });
                if (tokenModel != null)
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.Token);
                    var claims = token.Claims.ToList();

                    if (tokenModel.Token != null)
                    {
                        claims.Add(new Claim("realestatetoken", tokenModel.Token));
                        var claimsidentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authprops = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true
                        };
                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsidentity),authprops);
                        return RedirectToAction("Index", "Employee");

                    }
                }
            }
            return View();
        }
    }
}
