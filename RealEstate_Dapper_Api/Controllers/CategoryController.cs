using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Models.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository CategoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
           CategoryRepository = categoryRepository;
        }
        [HttpGet]
        public async Task <IActionResult> Get()
        {
            var values = await CategoryRepository.GetAllCategory();
            return Ok(values);
        }
        [HttpPost]
        public async Task <IActionResult> Post([FromBody]CreateCategoryDto categorydto)
        {
          await  CategoryRepository.CreateCategory(categorydto);
            return Ok("Kategori başarıyla eklendi");
        }
       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await CategoryRepository.DeleteCategory(id);
            return Ok("Başarıyla silindi");
        }
        [HttpPut]
        public IActionResult Put(UpdateCategoryDto categorydto)
        {
            CategoryRepository.UpdateCategory(categorydto);
            return Ok("Başarıyla güncellendi");
        }
        [HttpGet("{id}")]
        public async Task <IActionResult> Get(int id)
        {
            var category = await CategoryRepository.CategoryDetail(id);
            return Ok(category);
        }
    }
}
