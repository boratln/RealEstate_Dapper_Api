using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Models.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Models.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Repositories.BottomGridRepositories;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BottomGridController : ControllerBase
    {
        private readonly IBottomGridRepository _Ibottomgridrepository;
        public BottomGridController(IBottomGridRepository bottomgridrepository)
        {
            _Ibottomgridrepository = bottomgridrepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _Ibottomgridrepository.GetAllBottomGrid();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateBottomGridDto bottomGridDto)
        {
            _Ibottomgridrepository.CreateBottomGrid(bottomGridDto);
            return Ok("Kategori başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            _Ibottomgridrepository.DeleteBottomGrid(id);
            return Ok("Başarıyla silindi");
        }
        [HttpPut]
        public IActionResult Put(UpdateBottomGridDto bottomGridDto)
        {
            _Ibottomgridrepository.UpdateBottomGrid(bottomGridDto);
            return Ok("Başarıyla güncellendi");
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _Ibottomgridrepository.BottomGridDetail(id);
            return Ok(category);
        }
    }
}
