using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RealEstate_Dapper_UI.Dtos.ProductDetailDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Models;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apisettings;
        public PropertyController(IHttpClientFactory httpClientFactory,IOptions<ApiSettings> apisettings)
        {
            _httpClientFactory = httpClientFactory;
            _apisettings = apisettings.Value;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var responsemessage = await client.GetAsync("Product/ProductListWithCategory");
            if (responsemessage.IsSuccessStatusCode)
            {
                var JsonData = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDtos>>(JsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet("property/{slug}/{id}")]
        public async Task<IActionResult>PropertySingle(string slug, int id)
        {
			ViewBag.ProductId = id;
            var sessionid = 0;
            HttpContext.Session.SetInt32("id", id);
            sessionid = (int)HttpContext.Session.GetInt32("id");

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7093/api/Product/GetProductByProductId/{id}" );
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<ResultProductDtos>(jsonData);

			var client2 = _httpClientFactory.CreateClient();
			var responseMessage2 = await client2.GetAsync($"https://localhost:7093/api/ProductDetail/GetProductDetailByProduct/{sessionid}");
			var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
			var values2 = JsonConvert.DeserializeObject<GetByProductDetailIdDto>(jsonData2);

			ViewBag.ProductTitle = values.productTitle;
			ViewBag.ProductPrice = values.productPrice;
			ViewBag.City = values.city;
			ViewBag.District = values.district;
			ViewBag.Category = values.categoryName;
			ViewBag.img = values.ProductCoverImage;
			ViewBag.address = values.Address;
			ViewBag.Type = values.Type;
			ViewBag.Description = values.Description;

			ViewBag.BathRoomCount = values2.BathRoomCount;
			ViewBag.BedRoomCount = values2.BedRoomCount;
			ViewBag.roomCount = values2.RoomCount;
			ViewBag.garageSize = values2.GarageSize;
			ViewBag.buildYear = values2.BuildYear;
			ViewBag.price = values2.Price;
			ViewBag.location = values2.Location;
			ViewBag.videourl = values2.Videourl;
			ViewBag.size = values2.ProductSize;

			DateTime date = DateTime.Now;
			DateTime date2 = values.AdvertisementDate;
			TimeSpan timespan = date - date2;
			int month = timespan.Days / 30;
			ViewBag.month = month;
			ViewBag.date = values.AdvertisementDate;

			string slugFromTitle = CreateSlug(values.productTitle);
			ViewBag.slugUrl = slugFromTitle;

			return View();
		}

        public async Task<IActionResult> PropertyListWithSearch(string keyword, int categoryid, string city)
        {
            ViewBag.searchKeyValue = TempData["keyword"];
            ViewBag.propertyCategoryId = TempData["categoryid"];
            ViewBag.city = TempData["city"];

            keyword = TempData["keyword"].ToString();
            categoryid = int.Parse(TempData["categoryid"].ToString());
            city = TempData["city"].ToString();

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var responseMessage = await client.GetAsync($"https://localhost:7093/api/Product/ResultProductWithSearchList?keyword={keyword}&categoryid={categoryid}&city={city}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductListWithSearchDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        private string CreateSlug(string title)
        {
            title = title.ToLowerInvariant(); // Küçük harfe çevir
            title = title.Replace(" ", "-"); // Boşlukları tire ile değiştir
            title = System.Text.RegularExpressions.Regex.Replace(title, @"[^a-z0-9\s-]", ""); // Geçersiz karakterleri kaldır
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s+", " ").Trim(); // Birden fazla boşluğu tek boşluğa indir ve kenar boşluklarını kaldır
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s", "-"); // Boşlukları tire ile değiştir

            return title;
        }

        public async Task<IActionResult> PropertyDealsoftheDay()
        {
            var client=_httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apisettings.BaseUrl);
            var response = await client.GetAsync("Product/GetProductByDealOfTheDayTrueWithCategory");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<ResultProductDtos>(data);
                return View(json);
            }
            return View();
        }

    }
}
