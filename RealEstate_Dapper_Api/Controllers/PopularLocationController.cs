using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Models.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationController : ControllerBase
    {
        private readonly IPopularLocationRepository _IPopularLocationRepository;
        public PopularLocationController(IPopularLocationRepository ıPopularLocationRepository)
        {
            _IPopularLocationRepository = ıPopularLocationRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _IPopularLocationRepository.GetAllPopularLocation();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreatePopularLocationDto popularLocationDto)
        {
            await _IPopularLocationRepository.CreatePopularLocation(popularLocationDto);
            return Ok(" başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _IPopularLocationRepository.DeletePopularLocation(id);
            return Ok("Başarıyla silindi");
        }
        [HttpPut]
        public IActionResult Put(UpdatePopularLocationDto popularLocationDto)
        {
            _IPopularLocationRepository.UpdatePopularLocation(popularLocationDto);
            return Ok("Başarıyla güncellendi");
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var popularlocation = await _IPopularLocationRepository.PopularLocationDetail(id);
            return Ok(popularlocation);
        }
    }
}
