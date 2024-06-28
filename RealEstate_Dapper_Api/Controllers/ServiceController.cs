using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Models.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.ServiceRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _IServiceRepository;
        public ServiceController(IServiceRepository ıServiceRepository)
        {
            _IServiceRepository = ıServiceRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _IServiceRepository.GetAllServices();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateServiceDto categorydto)
        {
            await _IServiceRepository.CreateService(categorydto);
            return Ok("Kategori başarıyla eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _IServiceRepository.DeleteService(id);
            return Ok("Başarıyla silindi");
        }
        [HttpPut]
        public IActionResult Put(UpdateServiceDto categorydto)
        {
            _IServiceRepository.UpdateService(categorydto);
            return Ok("Başarıyla güncellendi");
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _IServiceRepository.ServiceDetail(id);
            return Ok(category);
        }
    }
}
