using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.ChartRepository;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.LastProductsRepository;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.StatisticRepository;
namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentDashboardController : ControllerBase
    {
        private readonly IStatisticRepository statisticRepository;
        private readonly IChartRepository _chartRepository;
        private readonly ILast5ProductRepository _last5ProductRepository;
        public EstateAgentDashboardController(IStatisticRepository statisticRepository, IChartRepository chart,ILast5ProductRepository last5ProductRepository)
        {
            this.statisticRepository = statisticRepository;
            _chartRepository=chart;
            _last5ProductRepository=last5ProductRepository;
        }
        [HttpGet("AllProductCount")]
        public IActionResult AllProductCount()
        {
           return Ok ( statisticRepository.AllProductCount());
        }
        [HttpGet("ProductCountByEmployeeId/{id}")]
        public IActionResult ProductCountByEmployeeId(int id) { 
        return Ok(statisticRepository.ProductCountByEmployeeId(id));
        }
        [HttpGet("ProductCountByStatusFalse/{id}")]   
        public IActionResult ProductCountByStatusFalse(int id)
        {
            return Ok(statisticRepository.ProductCountByStatusFalse(id));
        }
        [HttpGet("ProductCountByStatusTrue/{id}")]
        public IActionResult ProductCountByStatusTrue(int id)
        {
            return Ok(statisticRepository.ProductCountByStatusTrue(id));
        }
        [HttpGet("chart")]
        public async Task<IActionResult> chart()
        {
            var value = await _chartRepository.Get5CityForChart();
            return Ok(value);
        }
        [HttpGet("last5product/{id}")]
        public async Task<IActionResult> last5product(int id)
        {
            var value = await _last5ProductRepository.GetAllProduct5Async(id);
            return Ok(value);
        }
    }
}
