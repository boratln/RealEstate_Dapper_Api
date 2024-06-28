using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Models.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.Dtos.WhoWeAreDtos;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreDetailController : ControllerBase
    {

        private IWhoWeAreRepository _IwhoWeAreRepository;
        public WhoWeAreDetailController(IWhoWeAreRepository IwhoWeAreRepository)
        {
            _IwhoWeAreRepository = IwhoWeAreRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _IwhoWeAreRepository.GetResultWhoWeAreDetail();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateWhoWeAreDetailDto whoWeAreDetailDto)
        {
            await _IwhoWeAreRepository.CreateWhoWeAreDetail(whoWeAreDetailDto);
            return Ok(" başarıyla eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _IwhoWeAreRepository.DeleteWhoWeAreDetail(id);
            return Ok("Başarıyla silindi");
        }
        [HttpPut]
        public IActionResult Put(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            _IwhoWeAreRepository.UpdateWhoWeAreDetail(updateWhoWeAreDetailDto);
            return Ok("Başarıyla güncellendi");
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var weAreDetailDto = await _IwhoWeAreRepository.WhoWeAreDetail(id);
            return Ok(weAreDetailDto);
        }
    }
}
