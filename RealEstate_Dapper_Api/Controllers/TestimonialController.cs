using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Models.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.Dtos.TestimonialDtos;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.TestimonialRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController: ControllerBase
    {
        private readonly ITestimonialRepository _Itestimonialrepository;
        public TestimonialController(ITestimonialRepository ıtestimonialrepository)
        {
            _Itestimonialrepository = ıtestimonialrepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _Itestimonialrepository.GetAllTestimonials();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateTestimonialDto testimonialDto)
        {
            await _Itestimonialrepository.CreateTestimonial(testimonialDto);
            return Ok(" başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _Itestimonialrepository.DeleteTestimonial(id);
            return Ok("Başarıyla silindi");
        }
        [HttpPut]
        public IActionResult Put(UpdateTestimonialDto testimonialDto)
        {
            _Itestimonialrepository.UpdateTestimonial(testimonialDto);
            return Ok("Başarıyla güncellendi");
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var testimonial = await _Itestimonialrepository.TestimonialDetail(id);
            return Ok(testimonial);
        }
    }
}
