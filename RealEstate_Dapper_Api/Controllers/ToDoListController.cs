using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Models.Dtos.ToDoListDtos;
using RealEstate_Dapper_Api.Repositories.ToDoListRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private IToDoListRepository toDoListRepository;
        public ToDoListController(IToDoListRepository todolist)
        {
            toDoListRepository = todolist;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await toDoListRepository.GetAllToDoList();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateToDoListDto toDoListDto)
        {
            await toDoListRepository.CreateToDoList(toDoListDto);
            return Ok("Kategori başarıyla eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await toDoListRepository.DeleteToDoList(id);
            return Ok("Başarıyla silindi");
        }
        [HttpPut]
        public IActionResult Put(UpdateToDoListDto toDoListDto)
        {
            toDoListRepository.UpdateToDoList(toDoListDto);
            return Ok("Başarıyla güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await toDoListRepository.ToDoListDetail(id);
            return Ok(category);
        }
    }
}
