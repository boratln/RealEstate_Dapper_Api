using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.StatisticsRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IstatisticsRepository IstatisticsRepository;
        public StatisticsController(IstatisticsRepository statisticsRepository)
        {
            IstatisticsRepository = statisticsRepository;
        }
        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            return Ok(IstatisticsRepository.CategoryCount());
        }
        [HttpGet("ActiveEmployeeCount")]
        public IActionResult ActiveEmployeeCount()
        {
            return Ok(IstatisticsRepository.ActiveEmployeeCount());
        }
        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            return Ok(IstatisticsRepository.ActiveCategoryCount());
        }
        [HttpGet("ApartmentCount")]
        public IActionResult ApartmentCount()
        {
            return Ok(IstatisticsRepository.ApartmentCount());
        }
        [HttpGet("AverageProductPriceByRent")]
        public IActionResult AverageProductPriceByRent()
        {
            return Ok(IstatisticsRepository.AverageProductPriceByRent());
        }
        [HttpGet("AverageProductPriceBySale")]
        public IActionResult AverageProductPriceBySale()
        {
            return Ok(IstatisticsRepository.AverageProductPriceBySale());
        }
        [HttpGet("AvereageRoomCount")]
        public IActionResult AvereageRoomCount()
        {
            return Ok(IstatisticsRepository.AvereageRoomCount());
        }
        [HttpGet("CategoryNameByMaxProductCount")]
        public IActionResult CategoryNameByMaxProductCount()
        {
            return Ok(IstatisticsRepository.CategoryNameByMaxProductCount());
        }
        [HttpGet("CityNameByMaxProductCount")]
        public IActionResult CityNameByMaxProductCount()
        {
            return Ok(IstatisticsRepository.CityNameByMaxProductCount());
        }
        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            return Ok(IstatisticsRepository.PassiveCategoryCount());
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(IstatisticsRepository.ProductCount());
        }
        [HttpGet("LastProductPrice")]
        public IActionResult LastProductPrice()
        {
            return Ok(IstatisticsRepository.LastProductPrice());
        }
        [HttpGet("NewestBuildingYear")] 

        public IActionResult NewestBuildingYear()
        {
            return Ok(IstatisticsRepository.NewestBuildingYear());
        }
        [HttpGet("OldestBuildingYear")]
        public IActionResult OldestBuildingYear()
        {
            return Ok(IstatisticsRepository.OldestBuildingYear());
        }
        [HttpGet("EmployeeNameByMaxProductCount")]
        public IActionResult EmployeeNameByMaxProductCount()
        {
            return Ok(IstatisticsRepository.EmployeeNameByMaxProductCount());
        }
        [HttpGet("DifferentCityCount")]
        public IActionResult DifferentCityCount()
        {
            return Ok(IstatisticsRepository.DifferentCityCount());
        }



    }
}

