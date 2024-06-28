using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.AmenityRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenityController : ControllerBase
    {
        private readonly IAmenityRepository _amenityRepository;
        public AmenityController(IAmenityRepository amenityRepository)
        {
            _amenityRepository = amenityRepository;
        }

        [HttpGet("GetAmenityDtoByStatusTrue/{id}")]
        public async Task<IActionResult> GetAmenityDtoByStatusTrue(int id)
        {
            var values = await _amenityRepository.GetAmenityDtoByStatusTrue(id);
            return Ok(values);
        }
    }
}
